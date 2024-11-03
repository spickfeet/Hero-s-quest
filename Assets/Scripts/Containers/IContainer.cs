using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainer
{
    ItemType Item { get; }
    void CollectItem(ItemType item);
    void RemoveItem();
}
