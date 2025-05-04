using System.Runtime.CompilerServices;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager InventoryManager;
    void Start()
    {
      InventoryManager=GameObject.Find ("InventoryCanvas").GetComponent<InventoryManager> ();
    }

   private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy (gameObject);
        }
    }
    
}
