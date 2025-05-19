//TOP DOWN SHOOTING in Unity
//Brackeys
// Accessed 19 March 2025
// Version 3
//https://youtu.be/LNLVOjbrQj4?si=m_YMRHaFrIl__yZU


//Learn EVERYTHING About Particles in Unity | Easy Tutorial
//Sasquatch B Studios 
//Accessed 24 April 2025
//Version 3
//https://youtu.be/0HKSvT2gcuk?si=FmwG0J6uoJlbhm3D

using UnityEngine;

public class PlBulletDmg : MonoBehaviour
{
    public GameObject bullet;
    public int damage = 10;
   

    [SerializeField] private ParticleSystem playerDamage;
    private ParticleSystem enemyDamageParticleInstance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyHp>(out enemyHp enemyDamage))
        {
           
            enemyDamage.TakeDamage(damage);
            SpawnDamageParticles();
            Debug.Log(collision);
        }
      
        Destroy(bullet);
    }
    void SpawnDamageParticles()
    {
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.left, Vector2.right);
        enemyDamageParticleInstance = Instantiate(playerDamage, transform.position, Quaternion.identity);
    }

}
