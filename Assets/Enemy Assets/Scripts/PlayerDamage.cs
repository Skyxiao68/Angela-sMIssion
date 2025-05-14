using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Transform player;
    private Vector2 target;
    public float speed = 15;
    public int damageTaken = 5;

    [SerializeField] private ParticleSystem enemyDamage;

    private ParticleSystem playerDamageParticleInstance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
            Debug.Log("Player aint found");
        target = new Vector2(player.position.x, player.position.y);
        if (player == null)
            Debug.Log("Player position aint found");




    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health damageRecieved))
        {
            damageRecieved.RecieveDamage(damageTaken);
            SpawnDamageParticles();

            Destroy(gameObject);
        }


    }
   void SpawnDamageParticles()
{
        Quaternion spawnRotation = Quaternion.FromToRotation (Vector2.right,Vector2.left);
        playerDamageParticleInstance = Instantiate (enemyDamage, transform.position,Quaternion.identity);
}
    
}
