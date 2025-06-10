//Let's Make NPCs in Unity! | Episode 4 | Adding a Talk State
//Night Run Studio
//Accessed 5 May 2025
// Version 4
//https://youtu.be/-ERVFXfc-yY?si=NhjzROOHRy7eUqug

using System;
using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public enum State { Default, Idle, Patrol, Follow }
    public State currentState = State.Patrol;

    [Header("Components")]
    public Patrol patrol;
    public Follow follow;

    [Header("Detection raycast Settings")]
    public float detectionRange = 8f;
    public float detectionAngle = 90f;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;
    public float checkInterval = 0.15f;

    [Header("Detection Gameplay ")]
    public float detectionTime;
    public float detectionDistance;

    private float checkTimer;
    private Transform playerTransform;
    private Vector2 lastKnownPlayerPosition;
    public bool hasLineOfSight;
    public bool inVision;
    public Animator animator;
    public Material outline;
    public Material glow;
   

    void Start()
    {
      
        SwitchState(currentState);
        checkTimer = checkInterval;


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

      
        float angleToPlayer = Vector2.Angle(GetFacingDirection(), directionToPlayer);

        inVision = distanceToPlayer <= detectionRange &&
                       angleToPlayer <= detectionAngle / 2;

       
         hasLineOfSight = false;
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

     
        if (hasLineOfSight && currentState != State.Follow)
        {
            Debug.Log("Detected player! Switching to Follow");
            SwitchState(State.Follow);
        }
        else if (!hasLineOfSight && currentState == State.Follow)
        {
          
            if (Vector2.Distance(transform.position, lastKnownPlayerPosition) > detectionDistance)
            {
                Debug.Log("Lost sight of player, returning to patrol");
                StartCoroutine(lostLineOFSight());
               
            }
        }
    }

   

    Vector2 GetFacingDirection()
    {
      
        float angle = transform.eulerAngles.z;
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    public void SwitchState(State newState) //states switcher
    {
       
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
                    animator.SetBool ("Run",false);
                    animator.SetBool("Patrol", true);
                    outline.SetColor("_Color", Color.green);
                    glow.SetColor("_Color", Color.cyan);
                }
                break;

            case State.Follow:
                if (follow != null)
                {
                    follow.enabled = true;
                    follow.SetTarget(playerTransform);
                    animator.SetBool("Run", true);
                    animator.SetBool("Patrol", false);
                    outline.SetColor("_Color", Color.red);
                   
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
     IEnumerator lostLineOFSight()
    {
        yield return new WaitForSeconds(detectionTime);

        SwitchState(State.Patrol);
    }
}