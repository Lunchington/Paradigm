using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Inventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private ItemSlot[] itemSlots;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += uiOnItemListChanged;
        rebuildInventory();

    }

    private void uiOnItemListChanged(object sender, System.EventArgs e)
    {
        int emptySlot = getEmptySlot();

        foreach (Item item in inventory.GetItemList())
        {
            if (item.slot == -1) 
                item.slot = emptySlot;
            


        }

        rebuildInventory(); 
    }

    private void rebuildInventory()
    {

        for (int i = 0; i < itemSlots.Length; i++)
        {
            Item item = inventory.GetItemBySlot(i);

            if (item != null)
            {
                TextMeshProUGUI uiCount = itemSlots[i].transform.Find("Count").GetComponent<TextMeshProUGUI>();
                Image iImage = itemSlots[i].transform.Find("Item").GetComponent<Image>();



                if (item.count > 1)
                    uiCount.SetText(item.count.ToString());
                else
                    uiCount.SetText("");

                itemSlots[i].SetItem(true);
                iImage.sprite = item.getSprite();
                iImage.enabled = true;
            }
        }


    }

    public int getEmptySlot()
    {
        //get empty slot
        for (int i = 0; i < itemSlots.Length; i++)
        {
            ItemSlot iSlot = itemSlots[i];
            if (!iSlot.HasItem())
                return i;

        }
        return -1;
    }
}
