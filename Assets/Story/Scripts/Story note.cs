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
    private TextMeshPro continueText;
    public TextMeshProUGUI interact;

    private bool playerInRange;
    private void Start ()
    {
        storyTime.SetActive(false);
        interact.gameObject.SetActive(false);
       
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StoryTime();
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
        continueText.gameObject.SetActive (true);
        Time.timeScale = 0f;
    }
    void NoMoreStoryTime()
    {
        storyTime.SetActive(false);
        Pause.SetActive(true);
        playerUi.SetActive(true);
        resumeButton.SetActive(false);
        continueText.gameObject.SetActive(true);
        Time.timeScale = 1f; 
       
    
    }

}