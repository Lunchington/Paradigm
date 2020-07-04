using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public bool isDirty = false;

    [SerializeField] Transform prefabUiItem;

    [SerializeField] public Sprite itemSlotLocked;
    [SerializeField] Sprite itemSlotUnlocked;

    [SerializeField] private Ui_ItemSlot[] itemSlots;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.onItemAdded += uiItemAdded;
        inventory.onItemRemoved += uiItemRemoved;

        buildInventorySlots();
        //reBuildInventory();

    }


    private void Update()
    {
        if (isDirty)
        {
            foreach (Ui_ItemSlot itemSlot in itemSlots)
            {
                if (!isSlotEmpty(itemSlot))
                {

                    GameObject itemGO = itemSlot.transform.Find("Item").gameObject;

                    Item item = itemGO.GetComponent<Ui_Item>().GetItem();

                    TextMeshProUGUI itemCount = itemGO.GetComponentInChildren<TextMeshProUGUI>();


                    if (item.count > 1)
                        itemCount.SetText(item.count.ToString());
                    else
                        itemCount.SetText("");

                }
            }
            isDirty = false;
        }
    }

    private void uiItemAdded(Item item)
    {
        //adding a new item
        Ui_ItemSlot emptySlot = getEmptySlot();
        Transform newItem = Instantiate(prefabUiItem, Vector3.zero, Quaternion.identity);
  
        newItem.SetParent(emptySlot.transform);
        newItem.localPosition = Vector3.zero;
        newItem.name = "Item";

        newItem.transform.GetComponent<Ui_Item>().SetItem(item);
        newItem.transform.GetComponent<Image>().sprite = item.getSprite();

    }


    private void uiItemRemoved(Item item)
    {

    }
    private void buildInventorySlots()
    {
        int enabledSlots = inventory.EnabledSlots;

        foreach (Ui_ItemSlot itemSlot in itemSlots)
        {
            if (enabledSlots <= 0)
            {
                itemSlot.transform.Find("Background").GetComponent<Image>().sprite = itemSlotLocked;
                itemSlot.Lock();
            }
            enabledSlots -= 1;
        }  
    }

    public Ui_ItemSlot getEmptySlot()
    {
    
        foreach (Ui_ItemSlot itemSlot in itemSlots)
        {
            if (isSlotEmpty(itemSlot))
                return itemSlot;

        }
        return null;

    }

    public Inventory GetInventory()
    {
        return inventory;
    } 
    public bool isSlotEmpty(Ui_ItemSlot slot)
    {

        return slot.transform.Find("Item") == null;
    }
}
