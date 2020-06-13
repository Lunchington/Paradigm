
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private bool hasItem = false;
    
    public Boolean HasItem()
    {
        return hasItem;
    }

    internal void SetItem(bool hasItem)
    {
        this.hasItem = hasItem;
    }
}
