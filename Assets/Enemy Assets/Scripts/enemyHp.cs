

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
using UnityEngine.UI;

public class enemyHp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public AudioSource hitAud;
    public Material outline;
    public ParticleSystem playerParticle;

    [SerializeField] private Image bossHp;
    void Start()
    {
        currentHealth = maxHealth;
        outline.SetColor("_Color_1", Color.black);
    }

    private void Update()
    {
        float targetFillAmount = (float)currentHealth / maxHealth;
        bossHp.fillAmount = Mathf.Lerp(bossHp.fillAmount, targetFillAmount, Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
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
            Destroy(gameObject);
            
        //Animation here
    }

    IEnumerator shaderDamage()
    {
        outline.SetColor("_Color_1",Color.red);

        yield return new WaitForSeconds(0.5f);

        outline.SetColor("_Color_1", Color.black);
    }
}
