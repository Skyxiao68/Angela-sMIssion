//How To DAMAGE Enemies in Unity
//BMo
//Accessed 20 March 2025
//Version 2
//https://youtu.be/anHxFtiVuiE?si=SiLtQANzkFOzqH29

//Learn EVERYTHING About Particles in Unity | Easy Tutorial
//Sasquatch B Studios 
//Accessed 24 April 2025
//Version 2
//https://youtu.be/0HKSvT2gcuk?si=FmwG0J6uoJlbhm3D

////【【Unity3D像素游戏项目入门教程】20：——游戏中AudioSource音效的导入实现。-哔哩哔哩】 https://b23.tv/yLgx2SJ  <<//Hurt sound


using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyHp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public AudioSource hitAud;
    public AudioClip DeathAud;
    public Material outline;
    public ParticleSystem playerParticle;

    private bool isDead = false;
    private AudioSource deathAudioSource; 

    [SerializeField] private Image bossHp;

    void Start()
    {
        currentHealth = maxHealth;
        outline.SetColor("_Color_1", Color.black);

      
        deathAudioSource = gameObject.AddComponent<AudioSource>();
        deathAudioSource.playOnAwake = false;
        deathAudioSource.clip = DeathAud;
    }

    private void Update()
    {
        if (isDead) return;

        float targetFillAmount = (float)currentHealth / maxHealth;
        bossHp.fillAmount = Mathf.Lerp(bossHp.fillAmount, targetFillAmount, Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        hitAud.PlayOneShot(hitAud.clip);
        StartCoroutine(shaderDamage());
        Instantiate(playerParticle, transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; 
        isDead = true;

       
        DisableComponents();

        
        if (DeathAud != null && deathAudioSource != null)
        {
            deathAudioSource.Play();
        }

       
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        
        outline.SetColor("_Color_1", Color.gray);

       
        if (deathAudioSource != null && deathAudioSource.clip != null)
        {
            yield return new WaitForSeconds(deathAudioSource.clip.length);
        }
        else
        {
            
            yield return new WaitForSeconds(1f);
        }

       
        Destroy(gameObject);
    }

    void DisableComponents()
    {
       
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null) agent.enabled = false;

        
        Follow follow = GetComponent<Follow>();
        if (follow != null) follow.enabled = false;

        
        Controller controller = GetComponent<Controller>();
        if (controller != null) controller.enabled = false;

       
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;

       
        if (bossHp != null) bossHp.enabled = false;
    }

    IEnumerator shaderDamage()
    {
        outline.SetColor("_Color_1", Color.red);
        yield return new WaitForSeconds(0.5f);
        outline.SetColor("_Color_1", Color.black);
    }
}