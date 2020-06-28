using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Ui_Inventory uiInventory;


    private Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.gameObject.GetComponent<ItemWorld>();


        if (itemWorld != null)
        {

            int amountPickedup = inventory.AddItem(itemWorld.GetItem());


            if (amountPickedup <= 0)
                return;

            uiInventory.isDirty = true;

            if (amountPickedup >= itemWorld.GetItem().count)
            {
                itemWorld.DestroySelf();
            }
            else
            {
                itemWorld.GetItem().count -= amountPickedup;
                itemWorld.isDirty = true;
            }

            inventory.Refresh();

        }
    }

    public Ui_Inventory GetUi_Inventory()
    {
        return uiInventory;
    }
}
