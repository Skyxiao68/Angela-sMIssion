using UnityEngine;

public class Locked : MonoBehaviour
{
    public Rigidbody2D door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
