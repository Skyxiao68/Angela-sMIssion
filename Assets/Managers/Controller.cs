using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public enum State { Patrol, Follow }
    public State currentState = State.Patrol;

    [Header("Components")]
    public Patrol patrol;
    public Follow follow;

    [Header("Detection Settings")]
    public float detectionRange = 8f;
    public float detectionAngle = 90f;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;
    public float checkInterval = 0.15f;

    private float checkTimer;
    private Transform playerTransform;
    private Vector2 lastKnownPlayerPosition;

    void Start()
    {
        // ȷ����ʼ״̬��ȷ
        SwitchState(currentState);
        checkTimer = checkInterval;

        // �������
        FindPlayer();
    }

    void Update()
    {
        if (playerTransform == null)
        {
            FindPlayer();
            return;
        }

        checkTimer -= Time.deltaTime;
        if (checkTimer <= 0)
        {
            CheckForPlayer();
            checkTimer = checkInterval;
        }

        // ������Ϣ
        DebugState();
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
            Debug.Log("Player found: " + playerTransform.name);
        }
    }

    void CheckForPlayer()
    {
        Vector2 directionToPlayer = playerTransform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // ����Ƕȣ�ʹ��NPC��ǰ������
        float angleToPlayer = Vector2.Angle(GetFacingDirection(), directionToPlayer);

        // ��Ұ���
        bool inVision = distanceToPlayer <= detectionRange &&
                       angleToPlayer <= detectionAngle / 2;

        // ���߼��
        bool hasLineOfSight = false;
        if (inVision)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                directionToPlayer.normalized,
                detectionRange,
                obstacleLayer | playerLayer
            );

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                hasLineOfSight = true;
                lastKnownPlayerPosition = playerTransform.position;
                Debug.DrawRay(transform.position, directionToPlayer, Color.green, 0.5f);
            }
            else
            {
                Debug.DrawRay(transform.position, directionToPlayer, Color.yellow, 0.5f);
            }
        }

        // ״̬�л��߼�
        if (hasLineOfSight && currentState != State.Follow)
        {
            Debug.Log("Detected player! Switching to Follow");
            SwitchState(State.Follow);
        }
        else if (!hasLineOfSight && currentState == State.Follow)
        {
            // ��Ӷ��ݼ��䣺ʧȥ���ߺ��������Ƭ��
            if (Vector2.Distance(transform.position, lastKnownPlayerPosition) > 1f)
            {
                Debug.Log("Lost sight of player, returning to patrol");
                SwitchState(State.Patrol);
            }
        }
    }

    Vector2 GetFacingDirection()
    {
        // ������תȷ��ǰ������
        float angle = transform.eulerAngles.z;
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    public void SwitchState(State newState)
    {
        // ��������״̬���
        if (patrol != null) patrol.enabled = false;
        if (follow != null) follow.enabled = false;

        currentState = newState;
        Debug.Log("Switching to: " + newState);

        switch (newState)
        {
            case State.Patrol:
                if (patrol != null)
                {
                    patrol.enabled = true;
                    patrol.ResumePatrol();
                }
                break;

            case State.Follow:
                if (follow != null)
                {
                    follow.enabled = true;
                    follow.SetTarget(playerTransform);
                }
                break;
        }
    }

    void DebugState()
    {
        string stateInfo = $"Current State: {currentState}";
        if (playerTransform != null)
        {
            float dist = Vector2.Distance(transform.position, playerTransform.position);
            stateInfo += $"\nDistance to player: {dist:F1}";
        }
        Debug.Log(stateInfo);
    }

    void OnDrawGizmosSelected()
    {
        // ��Ұ׶��
        Gizmos.color = new Color(1, 1, 0, 0.3f);
        Vector2 origin = transform.position;
        Vector2 forward = GetFacingDirection() * detectionRange;

        Vector2 leftBound = Quaternion.Euler(0, 0, detectionAngle / 2) * forward;
        Vector2 rightBound = Quaternion.Euler(0, 0, -detectionAngle / 2) * forward;

        Gizmos.DrawLine(origin, origin + leftBound);
        Gizmos.DrawLine(origin, origin + rightBound);
        Gizmos.DrawLine(origin + leftBound, origin + forward);
        Gizmos.DrawLine(origin + rightBound, origin + forward);
    }
}