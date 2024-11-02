using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MinigameWorkStation : MonoBehaviour, IMinigameWorkStation
{
    public Action OnFinished { get; set; }

    public virtual void Add(ItemType item)
    {
    }

    public virtual void Cook()
    {
    }
}

