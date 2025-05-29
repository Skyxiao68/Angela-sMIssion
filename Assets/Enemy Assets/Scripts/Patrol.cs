//2D FOLLOW AI WITH UNITY AND C# - EASY TUTORIAL
//BlackThornProd
//25 March 2025
// Version 5
//https://youtu.be/rhoQd6IAtDo?si=Q3mMM1Iwr0QzgRVK

//2D Animation in Unity (Tutorial)
//Brackeys 
//7 May 2025'
//Version 3
//https://youtu.be/hkaysu1Z-N8?si=OW-1N5xC70DwbWEY


using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public float roamSpeed;
    public Transform[] moveSpots;
    public float startWaitTime = 1f;
    public Animator animator;
    private NavMeshAgent agent;
    private int randomSpot;
    private float waitTime;
    private bool isMoving = true;

    void Awake()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        agent.updateRotation =false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = 0.1f;
        agent.angularSpeed = 0f;
        agent.acceleration = 100f;
        agent.speed = roamSpeed;
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;

        agent.SetDestination(moveSpots[randomSpot].position);
        animator.SetBool("Patrol", true);
        animator.SetBool("Run", false);

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
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            isMoving = true;
           
            animator.SetBool("Patrol", true );
        }
        else // Reached point
        {
            if (agent.hasPath && agent.velocity.sqrMagnitude == 0f)
                isMoving = false;
            animator.SetBool("Patrol", false);
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
               
                isMoving = true; // Resume movement

                agent.SetDestination(moveSpots[randomSpot].position);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void ResumePatrol()
    {
        if (moveSpots.Length == 0) return;

        randomSpot = Random.Range(0, moveSpots.Length);
        agent.SetDestination(moveSpots[randomSpot].position);
        isMoving = true;
        animator.SetBool("Patrol", true);
    }
}