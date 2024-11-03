using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MinigameWorkStation : MonoBehaviour, IMinigameWorkStation
{
    [SerializeField] protected List<ItemType> _needItems;
    protected ItemType _resultItem;
    public Action<ItemType> OnFinished { get; set; }

    public virtual void Add(ItemType item)
    {
    }

    public virtual void Cook()
    {
    }

    public void Inject(List<ItemType> needItems, ItemType resultItem)
    {
        _needItems = needItems;
        _resultItem = resultItem;
    }
}

