
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item _item;

    private void Awake()
    {

        if (_item == null)
            this.GetComponent<Image>().enabled = false;

    }



}
