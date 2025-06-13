//How To DAMAGE Enemies in Unity
//BMo
//Accessed 2 April 2025
//Version 7
//https://youtu.be/anHxFtiVuiE?si=SiLtQANzkFOzqH29

//Learn EVERYTHING About Particles in Unity | Easy Tutorial
//Sasquatch B Studios 
//Accessed 26 April 2025
//Version 2
//https://youtu.be/0HKSvT2gcuk?si=FmwG0J6uoJlbhm3D



using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth = 0;
    public TextMeshProUGUI hpDisplay;
    public int amountHealed = 20;
    public GameObject gameOver;
    public ParticleSystem enemyParticle;
    public Image healthBar;

    [Header("Hurt Sound")]
    public AudioSource HurtAud;
    public AudioClip HurtSound;
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    void Start()
    {
        currentHealth = maxHealth;
       
        hpDisplay.text = maxHealth.ToString();

        if (HurtAud == null)
        {
            HurtAud = gameObject.AddComponent<AudioSource>();
            HurtAud.playOnAwake = false;
        }
    }
    public void Update()
    {
        float targetFillAmount = (float)currentHealth / maxHealth;
        healthBar.fillAmount = Mathf.Lerp (healthBar.fillAmount , targetFillAmount,Time.deltaTime);
    }

    public void RecieveDamage (int damageTaken)
    {
        currentHealth -= damageTaken;
        Instantiate(enemyParticle, transform.position, Quaternion.identity);

        PlayHurtSound();

        if (currentHealth<= 0)
        {
            Die();
        }
        hpDisplay.text = currentHealth.ToString();
      
    }

    void PlayHurtSound()
    {
        if (HurtAud != null && HurtSound != null)
        {
            HurtAud.pitch = Random.Range(minPitch, maxPitch);
            HurtAud.PlayOneShot(HurtSound);
        }
    }

    void Die()
    {

        //do an animation set a timer and then do the gameover 
         gameOver.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);

        
    }
    public void Heal (int amountHealed)
    {
        currentHealth += amountHealed;
    }

   
}
