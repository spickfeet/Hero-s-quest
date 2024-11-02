using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IItem
{
    private ItemType _type;
    public ItemType Type => _type;

    public Item(ItemType type)
    {
        _type = type;
    }
}
