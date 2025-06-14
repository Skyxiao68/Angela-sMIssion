using TMPro;
using UnityEngine;

public class door : MonoBehaviour
{
    public TextMeshProUGUI lockedText;
    public GameObject canavs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player "))
        {
            canavs.SetActive (true);
            lockedText.SetText("The door is locked i need to find the keycard (Top Left)");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canavs.SetActive (false);
    }

}
