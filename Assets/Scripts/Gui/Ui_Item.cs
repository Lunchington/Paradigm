using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Item : MonoBehaviour
{
    private Item item;

    public Item GetItem()
    {
        return item;
    }

    public void SetItem(Item item)
    {
        this.item = item;

    }
}
