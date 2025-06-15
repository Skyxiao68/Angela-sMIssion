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

    [Header("Medium Health Warning (66%)")]
    public AudioClip mediumHealthSound;
    [Range(0f, 1f)] public float mediumHealthVolume = 0.4f;
    public float mediumWarningInterval = 3f;

    [Header("Low Health Warning (33%)")]
    public AudioClip lowHealthSound;
    [Range(0f, 1f)] public float lowHealthVolume = 0.7f;
    public float lowWarningInterval = 1.5f;

    private AudioSource warningAudioSource;
    private float mediumWarningTimer;
    private float lowWarningTimer;
    private bool wasMediumHealth = false;
    private bool wasLowHealth = false;
    private const float MEDIUM_THRESHOLD = 0.66f;
    private const float LOW_THRESHOLD = 0.33f;

    void Start()
    {
        currentHealth = maxHealth;
        hpDisplay.text = maxHealth.ToString();

        if (HurtAud == null)
        {
            HurtAud = gameObject.AddComponent<AudioSource>();
            HurtAud.playOnAwake = false;
        }

        // Create dedicated audio source for warnings
        warningAudioSource = gameObject.AddComponent<AudioSource>();
        warningAudioSource.playOnAwake = false;
        warningAudioSource.loop = false;

        mediumWarningTimer = mediumWarningInterval;
        lowWarningTimer = lowWarningInterval;
    }

    public void Update()
    {
        float targetFillAmount = (float)currentHealth / maxHealth;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetFillAmount, Time.deltaTime);

        // Handle health warnings at both thresholds
        HandleHealthWarnings();
    }

    void HandleHealthWarnings()
    {
        float healthPercent = (float)currentHealth / maxHealth;
        bool isMediumHealth = healthPercent < MEDIUM_THRESHOLD && healthPercent >= LOW_THRESHOLD;
        bool isLowHealth = healthPercent < LOW_THRESHOLD;

        // Medium Health (66%) handling
        if (isMediumHealth)
        {
            // Just entered medium health state
            if (!wasMediumHealth)
            {
                mediumWarningTimer = 0; // Trigger immediate beep
                wasMediumHealth = true;
            }

            // Update timer and play sound
            mediumWarningTimer -= Time.deltaTime;
            if (mediumWarningTimer <= 0)
            {
                PlayWarningSound(mediumHealthSound, mediumHealthVolume);
                mediumWarningTimer = mediumWarningInterval;
            }
        }
        else if (wasMediumHealth)
        {
            // Exited medium health state
            wasMediumHealth = false;
        }

        // Low Health (33%) handling
        if (isLowHealth)
        {
            // Just entered low health state
            if (!wasLowHealth)
            {
                lowWarningTimer = 0; // Trigger immediate beep
                wasLowHealth = true;
            }

            // Update timer and play sound
            lowWarningTimer -= Time.deltaTime;
            if (lowWarningTimer <= 0)
            {
                PlayWarningSound(lowHealthSound, lowHealthVolume);
                lowWarningTimer = lowWarningInterval;
            }
        }
        else if (wasLowHealth)
        {
            // Exited low health state
            wasLowHealth = false;
        }

        // Stop all warnings if above both thresholds
        if (healthPercent >= MEDIUM_THRESHOLD && warningAudioSource.isPlaying)
        {
            warningAudioSource.Stop();
        }
    }

    void PlayWarningSound(AudioClip clip, float volume)
    {
        if (clip != null && warningAudioSource != null)
        {
            warningAudioSource.Stop(); // Stop any previous warning
            warningAudioSource.clip = clip;
            warningAudioSource.volume = volume;
            warningAudioSource.Play();
        }
    }

    public void RecieveDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        Instantiate(enemyParticle, transform.position, Quaternion.identity);
        PlayHurtSound();

        if (currentHealth <= 0)
        {
            Die();
        }

        hpDisplay.text = currentHealth.ToString();
    }

    private void Die()
    {
         gameOver.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
    }

    void PlayHurtSound()
    {
        if (HurtSound != null)
        {

            GameObject soundPlayer = new GameObject("TempAudio");
            soundPlayer.transform.position = transform.position;

            AudioSource tempSource = soundPlayer.AddComponent<AudioSource>();
            tempSource.clip = HurtSound;
            tempSource.pitch = Random.Range(minPitch, maxPitch);
            tempSource.volume = HurtAud.volume;
            tempSource.Play();

            Destroy(soundPlayer, HurtSound.length + 0.1f);
        }

    }
    public void Heal (int amountHealed)
    {
        currentHealth += amountHealed;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        hpDisplay.text = currentHealth.ToString();
    }
}