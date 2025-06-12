using UnityEngine;
using TMPro;
public class Stairtext : MonoBehaviour
{
    public TextMeshProUGUI playerText;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        playerText.SetText("I need to get to the VIP card first the stairs should be to the left of here");
    }
    
}
