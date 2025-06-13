using TMPro;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    private GameObject[] enemies;

    public GameObject win;



    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

       

        if (enemies.Length == 0)
        {
           win.SetActive(true);
        }

    }
}

