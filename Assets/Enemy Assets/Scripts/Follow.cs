//2D FOLLOW AI WITH UNITY AND C# - EASY TUTORIAL
//BlackThornProd
//25 March 2025
// Version 7
//https://youtu.be/rhoQd6IAtDo?si=Q3mMM1Iwr0QzgRVK

//2D Animation in Unity (Tutorial)
//Brackeys 
//7 May 2025'
//Version 3
//https://youtu.be/hkaysu1Z-N8?si=OW-1N5xC70DwbWEY

using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    [SerializeField] int speed = 10;
    private Transform target;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public Transform firePoint;
    [SerializeField] private ParticleSystem enemyMuzzle;
    private float distance;
  
   
    public GameObject bullet;

    private NavMeshAgent agent; 
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBetweenShots = startTimeBetweenShots;
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stoppingDistance;

    }

    void Start()
    {
        FindPlayer();

    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) target = player.transform;
    }
    void Update()
       
    {
        if (target == null)
        {
            FindPlayer();
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            agent.SetDestination(target.position);
           
        }

        else if (distance < stoppingDistance && distance > retreatDistance)
        {

            agent.ResetPath();
          
        }

        else if (distance < retreatDistance) {
        Vector2 retreatDirection = (transform.position - target.position).normalized;

            Vector2 retreatPosition = (Vector2)transform.position + retreatDirection*retreatDistance;
            
            agent.SetDestination(retreatPosition);
          
        }

        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = startTimeBetweenShots;
            Instantiate(enemyMuzzle, firePoint.position, firePoint.localRotation);
            Instantiate(bullet, firePoint.position, firePoint.localRotation);


        }
        else { timeBetweenShots -= Time.deltaTime; }

    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (agent != null && target != null)
        {
            agent.SetDestination(target.position);
        }
    }
    
}