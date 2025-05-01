using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletForce;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)==true)
        {
            shoot();
            //Instantiate shooting animation 
        }
    }
    void shoot()
    {
       GameObject bullet= Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce,ForceMode2D.Impulse);
    }
}
