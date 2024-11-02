using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainer
{
    IItem Item { get; }
    void CollectItem(IItem item);
    void RemoveItem();
}
