//TOP DOWN SHOOTING in Unity
//Brackeys
// Accessed 19 March 2025
// Version 6 
//https://youtu.be/LNLVOjbrQj4?si=m_YMRHaFrIl__yZU


//Ammo & Reloading - Unity Tutorial
//Brackeys
//Accessed 24 April 2025
//Version 3
//https://youtu.be/kAx5g9V5bcM?si=akxlKeR5pitfQWKR


//Learn EVERYTHING About Particles in Unity | Easy Tutorial
//Sasquatch B Studios 
//Accessed 24 April 2025
//Version 2
//https://youtu.be/0HKSvT2gcuk?si=FmwG0J6uoJlbhm3D


//CAMERA SHAKE in Unity
//Brackeys
//Accessed 26 April 2025
//Version 2
//https://youtu.be/9A9yj8KnM8c?si=l04Ec1sOjvcc9A4J



//【【Unity3D像素游戏项目入门教程】20：——游戏中AudioSource音效的导入实现。-哔哩哔哩】 https://b23.tv/yLgx2SJ  <<//Gun sound

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
    private bool isReloading = false;
    public ParticleSystem muzzleFlash;
    
    private ParticleSystem muzzleFlashInstance;

    public Animator animator;

    public AudioSource ShootingAud;
    public AudioSource ReloadAud;
    public AudioSource ShellAud;

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

        if (isReloading)
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
        

    
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        ReloadAud.PlayOneShot(ReloadAud.clip);
        animator.SetBool("IsReloading",true);
        isReloading = true;
        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        animator.SetBool("IsReloading",false);

    }

    IEnumerator ShootGun()
    {
        ShootingAud.PlayOneShot(ShootingAud.clip);
        ShellAud.PlayOneShot(ShellAud.clip);
        SpawnDamageParticles();
        //CameraShakeManager.instance.CameraShake(impulseSource);
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
