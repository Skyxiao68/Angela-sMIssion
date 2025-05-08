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
        InventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();


    }
   private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //could add an input to increase player interactivity here
        {
            InventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);

        }
    }
}
