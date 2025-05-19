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


    private void Start ()
    {
        storyTime.SetActive(false);
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StoryTime();
        }
          
    }

    public void Resume()
    {
        NoMoreStoryTime();

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
        Destroy(gameObject);
    
    }

}