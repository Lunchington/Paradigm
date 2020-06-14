using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemAssetController : MonoBehaviour
{
    public static ItemAssetController Instance { get; set; }

    // Update is called once per frame
    void Awake()
    {
        Instance = this;
        itemPrototypes = new Dictionary<string, Item>();
    }

    public Sprite stoneSprite;
    public Sprite stickSprite;
    public Sprite stringSprite;
    public Sprite leatherSprite;

    public Sprite noneSprite;

    public Transform prefabItemWorld;

    public Dictionary<string, Item> itemPrototypes;


    public Item GetItemPrototype(string localizedName)
    {
        switch(localizedName)
        {
            default:
                return null;
            case "itemLeather":
                return new Item { type = ItemType.CONSUMABLE, maxSize = 1, localizedName = "itemLeather" };
            case "itemStick":
                return new Item { type = ItemType.CONSUMABLE, maxSize = 1, localizedName = "itemStick" };
            case "itemStone":
                return new Item { type = ItemType.CONSUMABLE, maxSize = 64, localizedName = "itemStone" };
            case "itemString":
                return new Item { type = ItemType.CONSUMABLE, maxSize = 64, localizedName = "itemString" };
        }

        return itemPrototypes[localizedName];
    }
}
