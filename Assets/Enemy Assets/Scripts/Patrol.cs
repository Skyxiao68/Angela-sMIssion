using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float roamSpeed = 20f;
    public Transform[] moveSpots;
    public float startWaitTime = 1f;
    public Animator animator;

    private int randomSpot;
    private float waitTime;
    private bool isMoving = true;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
        animator.SetBool("Switch", false);
    }

    void Update()
    {
        // Only update direction/rotation WHILE MOVING
        if (isMoving)
        {
            Vector2 direction = moveSpots[randomSpot].position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Movement logic
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) > 0.2f)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position,
                                                  moveSpots[randomSpot].position,
                                                  roamSpeed * Time.deltaTime);
        }
        else // Reached point
        {
            isMoving = false;
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                isMoving = true; // Resume movement
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}