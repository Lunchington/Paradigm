using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public string itemName;
    public int count = 1;
    private void Start()
    {
        Item item = ItemAssetController.Instance.GetItemPrototype(itemName);
        item.count = count;

        ItemWorld.SpawnItemWorld(transform.position, item);
        Destroy(gameObject);

        
    }
}
