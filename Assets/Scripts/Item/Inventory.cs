using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Inventory
{

	public Action<Item> onItemAdded;
	public Action<Item> onItemRemoved;

	private List<Item> itemList;

	private int size = 40;

	private int _enabledSlots = 2;
	private int _availableSlots = 2;

	public int enabledSlots { 
		get { return _enabledSlots; }
		set { _enabledSlots = value; }

	}
	public int availableSlots {
		get { return _availableSlots; }
		set { _availableSlots = value; }
	}

	public Inventory ()
		:this(3)
	{
		itemList = new List<Item>();

	}

	public Inventory ( int _slots)
	{
		this._enabledSlots = _slots;
		this._availableSlots = _slots;
	}

	public int AddItem(Item item)
	{	

		if (item.isStackable())
		{
			if (isItemInInventory(item))
			{
				//if its already here and stackable
				int currAmout = 0;

				foreach (Item currItem in itemList)
				{
					//Found item thats a duplicate
					if (currItem.localizedName == item.localizedName)
					{

						//it isnt max sized
						if (currItem.count < currItem.maxSize)
						{

							int valueLeft = currItem.maxSize - currItem.count;
							//if there is more value left than item being added contains just return count
							if (valueLeft >= item.count)
							{
								currItem.count += item.count;
								return item.count;
							}
							// There is more item than available value... so make a new slot?

							//no new slot available, leave item on ground
							currItem.count += valueLeft;
							currAmout = valueLeft;

							if (itemList.Count < _availableSlots)
							{
								//We have a free slot;
								item.count -= valueLeft;
								AddNewItem(item);
								return item.count;

							}
							
						}

						//SLOT FULL BUT WE HAVE AN AVAILABLE ONE!
						if (itemList.Count < _availableSlots)
						{
							return AddNewItem(item);

						}

					}
				}
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
		if (itemList.Count == _availableSlots )
			return 0;

		itemList.Add(item);
		onItemAdded(item);
		return item.count;
	}

	public void RemoveItem(Item item)
	{
		itemList.Remove(item);
		onItemRemoved(item);

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
