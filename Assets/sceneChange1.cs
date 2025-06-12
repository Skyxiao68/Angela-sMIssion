using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChangeLvl2 : MonoBehaviour
{
    public bool playerInRange;
    public TextMeshProUGUI interact;
    public GameObject Eishhhghhhhhhhh;//ps im dumb lmfaoooooo

    public void Start()
    {
        interact.gameObject.SetActive (false);
        playerInRange = false ;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadSceneAsync(5);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {  
            
            Eishhhghhhhhhhh.gameObject.SetActive (true);
             interact.gameObject.SetActive (true);
            interact.SetText("Press E to go to the basement");
            playerInRange = true; 
        }
       
           
        
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Eishhhghhhhhhhh.gameObject.SetActive(false);
            interact.gameObject.SetActive(false);
        }
    }
}
  
