
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ui_ItemSlot : MonoBehaviour, IDropHandler
{
    private bool locked = false;

    public virtual void OnDrop(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);

        //if this slot is locked or there is no data dont even bother!
        if (locked || eventData.pointerDrag == null)
        {
            Debug.Log("LOCKED ");
            return;
        }


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
    }
   
    public void Lock()
    {
        locked = true;
    }

   

}
