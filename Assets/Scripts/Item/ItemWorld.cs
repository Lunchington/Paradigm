using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;
    public bool isDirty;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
       
    }

    private void Update()
    {
        if (item.count <= 0)
            DestroySelf();

        if (isDirty)
        {
            updateText();
            isDirty = false;
        }
    }

    public static ItemWorld SpawnItemWorld( Vector3 position, Item item)
    {
        Transform transform =  Instantiate(ItemAssetController.Instance.prefabItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();

        itemWorld.SetItem(item);
        return itemWorld;

    }

    public void SetItem (Item item)
    {
        if (item.count > item.maxSize)
            item.count = item.maxSize;

        this.item = item;

        spriteRenderer.sprite = this.item.getSprite();

        updateText();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void updateText()
    {
        if (this.item.count > 1)
        {
            textMeshPro.SetText(this.item.count.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }

    }
    
}
