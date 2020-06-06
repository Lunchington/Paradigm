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

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public ItemType type;
    public int count;
    
}
