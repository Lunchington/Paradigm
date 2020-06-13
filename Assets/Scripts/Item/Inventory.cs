using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{

	public event EventHandler OnItemListChanged;
	private List<Item> itemList;

	private int size = 40;
	private int enabledSlots = 5;

	public Inventory ()
	{
		itemList = new List<Item>();

	}

	public void AddItem(Item item)
	{
		if (itemList.Count >= size || itemList.Count >= enabledSlots)
			return;

		if (item.isStackable())
		{
			bool itemInInventory = false;
			foreach (Item i in itemList)
			{
				if (i.localizedName == item.localizedName)
				{

					i.count += item.count;
					itemInInventory = true;

				}

			}
			if (!itemInInventory)
			{
				itemList.Add(item);
			}
		} 
		else
		{
			itemList.Add(item);
		}

		OnItemListChanged?.Invoke(this, EventArgs.Empty);
	}

	public List<Item> GetItemList()
	{
		return itemList;
	}


	public Item GetItemBySlot(int slot)
	{
		foreach (Item item in itemList)
		{
			if (item.slot == slot)
				return item;

		}
		return null;
	}


}
