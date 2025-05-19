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

    void Awake()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
     
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
            transform.position = Vector2.MoveTowards(transform.position,moveSpots[randomSpot].position,
                                                  roamSpeed * Time.deltaTime);
            animator.SetBool("Patrol", true);
        }
        else // Reached point
        {
            isMoving = false;
            animator.SetBool("Patrol", false);
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