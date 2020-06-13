using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    EQUIPABLE,
    CONSUMABLE,
    MISC
}

public class Item
{

    public String localizedName;
    public String description;

    public ItemType type;

    public int count = 1 ;
    public int slot = -1;
    public int maxSize = 1;


    public Sprite getSprite()
    {
        switch(localizedName)
        {
            default: 
                return ItemAssetController.Instance.noneSprite;
            case "itemStone":
                return ItemAssetController.Instance.stoneSprite;
            case "itemStick":
                return ItemAssetController.Instance.stickSprite;
            case "itemString":
                return ItemAssetController.Instance.stringSprite;
            case "itemLeather": 
                return ItemAssetController.Instance.leatherSprite;
        }
    }

    public bool isStackable()
    {
        if (maxSize > count)
            return true;

        return false;
    }
   

}
