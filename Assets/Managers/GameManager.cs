

//How To Make Enemy Counter In UNITY
//Kgdee
//Accessed 13 May 2025
//Version 3
//https://youtu.be/ihgH6LRGVks?si=zBtamSf1QUEFCkRz



using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject [] enemies;
    public TextMeshProUGUI enemyCountText;
  
   

  
    void Update()
    {

        string currentScene = SceneManager.GetActiveScene().name;
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCountText.text = "Enemies left: " + enemies.Length.ToString();

        if (enemies.Length == 0)
        {
            switch(currentScene)
            {
                case "Level 1":
                    enemyCountText.text = "I need to make my way to the second floor (Top Left)";
                    break;

                case "Level 2":
                    enemyCountText.text = "I need to get to the basement (bottom right)";
                    break;
                case "Level 3":
                    enemyCountText.text = "Where is Molina!";
                    break;
            }
          
        }
        else
        {
            enemyCountText.text = "Enemies Left: " + enemies.Length.ToString();
        }
    }
}
