﻿
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ui_ItemSlot : MonoBehaviour, IDropHandler
{
    private Ui_Inventory uiInventory;
    private bool locked = false;


    [SerializeField] public TextMeshProUGUI ItemText;

    private void Awake()
    {
        uiInventory = GetComponentInParent<Ui_Inventory>();
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        //if this slot is locked or there is no data dont even bother!
        if (locked || eventData.pointerDrag == null)
            return;


        Transform prevSlottedItem = transform.Find("Item");
        Transform dragItem = eventData.pointerDrag.transform;

        //if there is an item in the slot swap with dragged item
        if (prevSlottedItem != null)
            SetNewSlot(prevSlottedItem, dragItem.GetComponent<Ui_ItemDragDrop>().startParent);

        //set dragged item to slot
        SetNewSlot(dragItem, transform);  
    }

    private void SetNewSlot(Transform item , Transform parent)
    {
        item.SetParent(parent);
        item.GetComponentInParent<RectTransform>().anchoredPosition = Vector3.zero;
        item.GetComponentInParent<Ui_ItemSlot>().ItemText = item.Find("Count").GetComponent<TextMeshProUGUI>();
    }
   
    public void Lock()
    {
        locked = true;
    }

   

}
