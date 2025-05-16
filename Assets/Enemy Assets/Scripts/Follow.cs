using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Follow : MonoBehaviour
{
    [SerializeField] int speed = 10;
    public Transform target;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public Transform firePoint;
    [SerializeField] private ParticleSystem enemyMuzzle;
    private float distance;
    public Animator animator;
    public GameObject bullet;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBetweenShots = startTimeBetweenShots;
        animator.SetBool("Switch", true);
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && (Vector2.Distance(transform.position, target.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle); 

        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = startTimeBetweenShots;
            Instantiate(enemyMuzzle ,firePoint.position,firePoint.localRotation);
            Instantiate(bullet, firePoint.position, firePoint.localRotation);
          
           
        }
        else { timeBetweenShots -= Time.deltaTime; }

       






    }
}
