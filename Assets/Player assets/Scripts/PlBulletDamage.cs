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
