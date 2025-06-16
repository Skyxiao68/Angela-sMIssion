//Wrote this my self on the 23 May 2025 using all the knowledge gained thus far


using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public GameObject Pause;
    public GameObject storyTime;
    public GameObject playerUi;
    public GameObject resumeButton;

    public TextMeshProUGUI interact;


    [Header("Pickup Sound")]
    public AudioClip pickupSound;
    [Range(0f, 1f)] public float volume = 0.7f;
    public float minPitch = 0.95f;
    public float maxPitch = 1.05f;

    private bool playerInRange;

    private void Start()
    {
        storyTime.SetActive(false);
        interact.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PlayPickupSound(); 
            StoryTime();
        }
    }

    void PlayPickupSound()
    {
        if (pickupSound != null)
        {
         
            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = transform.position;
            AudioSource audioSource = tempGO.AddComponent<AudioSource>();
            audioSource.clip = pickupSound;
            audioSource.volume = volume;
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();
            Destroy(tempGO, pickupSound.length); 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            interact.gameObject.SetActive(true);
            interact.SetText("Press E to pickup");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            interact.gameObject.SetActive(false);
        }
    }

    public void Resume()
    {
        NoMoreStoryTime();
        Destroy(gameObject);
    }

    void StoryTime()
    {
        storyTime.SetActive(true);
        Pause.SetActive(false);
        playerUi.SetActive(false);
        Time.timeScale = 0f;
    }

    void NoMoreStoryTime()
    {
        storyTime.SetActive(false);
        Pause.SetActive(true);
        playerUi.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Bossssss()
    {
        //Scene
    }
}