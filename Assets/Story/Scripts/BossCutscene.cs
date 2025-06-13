using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BossCutscene : MonoBehaviour
{
    public GameObject Paused;
    public GameObject bossCut;
    public GameObject playerUii;
    public GameObject resumeButton;

    public TextMeshProUGUI cutTex;

   public bool playerInSpace;
    private void Start()
    {
        bossCut.SetActive(false);
        cutTex.gameObject.SetActive(false);

    }

    private void Update ()
    {
        if (playerInSpace && Input.GetKeyDown(KeyCode.E))
        {
            BossTime();
        }
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInSpace = true;
            cutTex.gameObject.SetActive(true);
            cutTex.SetText("Press E to begin the boss fight");

        }

    }
    public void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInSpace = false;
            cutTex.gameObject.SetActive(false);
        }
    }
    public void Resume ()
    {
        bossScene();
        

    }
    void BossTime()
    {
       bossCut.SetActive(true);
        Paused.SetActive(false);
        playerUii.SetActive(false);

        Time.timeScale = 0f;
    }
    void bossScene()
    {
        //Scene change

    }

}
