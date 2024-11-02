using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Pick : MonoBehaviour, IPickable
{
    public void PickUp(Transform transform)
    {
        transform.position = Input.mousePosition;
    }
}