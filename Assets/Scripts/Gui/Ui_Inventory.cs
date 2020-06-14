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

    [SerializeField] Sprite itemSlotLocked;
    [SerializeField] Sprite itemSlotUnlocked;

    [SerializeField] private Ui_ItemSlot[] itemSlots;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.onItemAdded += uiItemAdded;

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
                    Item item = itemSlot.transform.Find("Item").GetComponent<Ui_Item>().GetItem();

                    if (item.count > 1)
                        itemSlot.ItemText.SetText(item.count.ToString());
                    else
                        itemSlot.ItemText.SetText("");

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
  

        emptySlot.ItemText = newItem.transform.Find("Count").GetComponent<TextMeshProUGUI>();

        newItem.SetParent(emptySlot.transform);
        newItem.localPosition = Vector3.zero;
        newItem.name = "Item";

        newItem.transform.GetComponent<Ui_Item>().SetItem(item);
        newItem.transform.GetComponent<Image>().sprite = item.getSprite();


  

    }

    private void buildInventorySlots()
    {
        int enabledSlots = inventory.EnabledSlots;

        foreach (Ui_ItemSlot itemSlot in itemSlots)
        {
            if (enabledSlots <= 0)
            {
                itemSlot.transform.Find("Background").GetComponent<Image>().sprite = itemSlotLocked;
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

    public bool isSlotEmpty(Ui_ItemSlot slot)
    {

        return slot.transform.Find("Item") == null;
    }
}
