﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Inventory 
{

	public Action<Item> onItemAdded;
	private List<Item> itemList;

	private int size = 40;

	private int enabledSlots = 2;
	private int availableSlots = 2;

	public int EnabledSlots { get { return enabledSlots; } }
	public Inventory ()
	{
		itemList = new List<Item>();

	}

	public int AddItem(Item item)
	{	

		if (item.isStackable())
		{

			if (isItemInInventory(item))
			{
				//if its already here and stackable
				int currAmout = 0;
				Item newItem = null;

				foreach (Item currItem in itemList)
				{
					//Found item thats a duplicate
					if(currItem.localizedName == item.localizedName)
					{
						//it isnt max sized
						if (currItem.count < currItem.maxSize)
						{
							int valueLeft = currItem.maxSize - currItem.count;
							Debug.Log("VALUE LEFT: " + valueLeft);
							//if there is more value left than item being added contains just return count
							if (valueLeft >= item.count)
							{
								currItem.count += item.count;

								Debug.Log("Item Count in inventory: " + currItem.count);
								return item.count;

							}
							// There is more item than available value... so make a new slot?

							//no new slot available, leave item on ground
							currItem.count += valueLeft;
							currAmout = valueLeft;

							if (itemList.Count < availableSlots)
							{
								//We have a free slot;
								newItem = item;
								currAmout = currItem.count;
								Debug.Log(currAmout);

							}


						}

					}
					

				}
				if (newItem != null) 
						AddNewItem(newItem);

				return currAmout;
			}
			else
			{
				//its not here add as normal 
				return AddNewItem(item);
			}
		}
		else
		{
			//not stackable add as normal
			return AddNewItem(item);
		}


	}

	private int AddNewItem(Item item)
	{
		if (itemList.Count == availableSlots )
			return 0;

		itemList.Add(item);

		onItemAdded(item);
		return item.count;
	}

	public void Refresh()
	{
	}

	public List<Item> GetItemList()
	{
		return itemList;
	}

	public bool isItemInInventory(Item item)
	{
		return itemList.Find(i => i.localizedName.Equals(item.localizedName)) != null;
	}

}
