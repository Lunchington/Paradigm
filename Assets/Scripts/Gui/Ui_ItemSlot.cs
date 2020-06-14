
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ui_ItemSlot : MonoBehaviour, IDropHandler
{
    private Ui_Inventory uiInventory;

    [SerializeField] public TextMeshProUGUI ItemText;

    private void Awake()
    {
        uiInventory = GetComponentInParent<Ui_Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {

        //if(eventData.pointerDrag != null)
        //{
        //    Transform dragTransform = eventData.pointerDrag.transform;
        //    dragTransform.SetParent(transform);

        //    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        //}
    }

}
