using UnityEngine;
using TMPro;
public class Stairtext : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    public GameObject canvas;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        canvas.SetActive(true);
        playerText.SetText("I need to get to the VIP card first the stairs should be to the left of here");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }

}
