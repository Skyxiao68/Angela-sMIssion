using UnityEngine;

public class PlBulletDmg : MonoBehaviour
{
    public GameObject bullet;
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyHp>(out enemyHp enemyDamage))
        {
            enemyDamage.TakeDamage(damage);
            Debug.Log(collision);
        }
        Destroy(bullet);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(bullet);
    }
}
