using UnityEngine;
using System.Collections;
using System;
using TMPro;
using Unity.Cinemachine;
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
    private float nextShotTime;
    private bool isReloaing = false;
    public ParticleSystem muzzleFlash;
    
    private ParticleSystem muzzleFlashInstance;

   
  
    
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        currentAmmo = maxAmmo;
       impulseSource = GetComponent<CinemachineImpulseSource>();
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
        if (Input.GetButton("Fire1") && Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + 1f / fireRate;
            StartCoroutine(ShootGun());
        }
        //Instantiate shooting animation 

    
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

    IEnumerator ShootGun()
    {

        SpawnDamageParticles();
        CameraShakeManager.instance.CameraShake(impulseSource);
;        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        currentAmmo--;

        Destroy(bullet, 10f);
        yield return new WaitForSeconds(fireRate);
        
    }

    private void SpawnDamageParticles()
    {
        muzzleFlashInstance = Instantiate (muzzleFlash,firePoint.position, firePoint.rotation);
     
        
    }

}
