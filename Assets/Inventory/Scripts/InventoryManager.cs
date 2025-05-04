using UnityEngine;
using Unity.VisualScripting;
using NUnit.Framework.Constraints;
using JetBrains.Annotations;
public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public InventorySlot[] itemSlots;
    void Start()
    {
        InventoryMenu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
            DeselectAllSlots();

            Time.timeScale = 0;
            Debug.Log("U paused");

        }

    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull == false)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }

        }
    }
    public void DeselectAllSlots()
{
        for (int i = 0; i < itemSlots.Length; i++) 
        
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].itemSelected =  false;

        
          
        }
}


}

