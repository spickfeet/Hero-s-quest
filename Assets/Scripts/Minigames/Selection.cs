using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Selection : MonoBehaviour, IPickable
{
    [SerializeField] private Vector2 _basePos;

    private void Awake()
    {
        _basePos = new Vector2(-10000, -1000);
    }

    public void PickUp(Transform transform)
    {
        if(_basePos == new Vector2(-10000, -1000))
        {
            _basePos = transform.position;
        }
        transform.position = Input.mousePosition;
    }

    public void Drop(Transform transform)
    {
        transform.position = _basePos;
        _basePos = new Vector2(-10000,-1000);
    }
}