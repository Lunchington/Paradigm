using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Ui_Inventory uiInventory;
    private Inventory _inventory;
    public Inventory inventory { get { return _inventory; } set { this._inventory = value; } }

    private void Awake()
    {
        _inventory = new Inventory();
        uiInventory.SetInventory(_inventory);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.gameObject.GetComponent<ItemWorld>();


        if (itemWorld != null)
        {

            int amountPickedup = _inventory.AddItem(itemWorld.item);


            if (amountPickedup <= 0)
                return;

            uiInventory.isDirty = true;

            if (amountPickedup >= itemWorld.item.count)
            {
                itemWorld.DestroySelf();

            }
            else
            {
                itemWorld.item.count -= amountPickedup;
            }

            inventory.Refresh();

        }
    }

    public Ui_Inventory GetUi_Inventory()
    {
        return uiInventory;
    }
}
