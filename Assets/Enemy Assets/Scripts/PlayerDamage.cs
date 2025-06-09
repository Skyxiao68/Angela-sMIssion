//How To DAMAGE Enemies in Unity
//BMo
//Accessed 20 March 2025
//Version 6
//https://youtu.be/anHxFtiVuiE?si=SiLtQANzkFOzqH29




using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Transform player;

    public float force = 25;
    public int damageTaken = 5;
    public float despawnBullet;

    private Rigidbody2D rb;

    [SerializeField] private ParticleSystem enemyDamage;

    private ParticleSystem playerDamageParticleInstance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
            Debug.Log("Player aint found");
        

        Vector3 direction = player.transform.position -  transform.position;
        rb.linearVelocity = new Vector2 (direction.x, direction.y).normalized * force;

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health damageRecieved))
        {
            damageRecieved.RecieveDamage(damageTaken);
            SpawnDamageParticles();

            Destroy(gameObject);


            
            
              if (Input.GetKeyDown(KeyCode.Space))
                {

                    damageRecieved.RecieveDamage(damageTaken);
                Debug.Log("Is thyis thijg one");

                }
            
        }


    }
   void SpawnDamageParticles()
{
        Quaternion spawnRotation = Quaternion.FromToRotation (Vector2.right,Vector2.left);
        playerDamageParticleInstance = Instantiate (enemyDamage, transform.position,Quaternion.identity);
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
