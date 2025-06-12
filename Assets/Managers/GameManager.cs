

//How To Make Enemy Counter In UNITY
//Kgdee
//Accessed 13 May 2025
//Version 3
//https://youtu.be/ihgH6LRGVks?si=zBtamSf1QUEFCkRz



using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{ public GameObject [] enemies;
    public TextMeshProUGUI enemyCountText;
  
   

  
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCountText.text = "Enemies left: " + enemies.Length.ToString();

        if (enemies.Length == 0)
        {
            enemyCountText.SetText("Get to the second floor (Top-Left)");
        }
    
    }
}
