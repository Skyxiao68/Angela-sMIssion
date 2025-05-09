using UnityEngine;
using System.Collections;
using System;
using TMPro;
public class Shoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletForce;

    public float fireRate;
    public float reloadTime;
    public TMPro.TextMeshProUGUI totalAmmo;
    public TMPro.TextMeshProUGUI ammoLeft;
    public float maxAmmo;
    private float currentAmmo;
    private bool isReloaing = false;
    public ParticleSystem muzzleFlash;
    public CameraFollow cameraShake;

    private ParticleSystem muzzleFlashInstance;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo; ;


    }

    void Update()
    {

        totalAmmo.text = maxAmmo.ToString();
        ammoLeft.text = currentAmmo.ToString();

        if (isReloaing)
            return;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();

            //Instantiate shooting animation 

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {

        isReloaing = true;
        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloaing = false;


    }

    void shoot()
    {
        SpawnDamageParticles();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        currentAmmo--;

        Destroy(bullet, 10f);
    }

    private void SpawnDamageParticles()
    {
        muzzleFlashInstance = Instantiate (muzzleFlash,firePoint.position, firePoint.rotation);

    }
}
