using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Selection : MonoBehaviour, IPickable
{
    [SerializeField] private Vector2 _basePos;

    private Transform _currentTransform;

    public Transform CurrentTransform
    {
        get => _currentTransform;
        set => _currentTransform = value;
    }
    private bool _drag;
    public bool Drag => _drag;

    private void Awake()
    {
        ResetPos();
        _drag = false;
    }

    public void ResetPos()
    {
        Debug.Log(100);
        _basePos = new Vector2(-10000, -1000);
    }

    public void PickUp(Transform transform)
    {
        CurrentTransform = transform;
        _drag = true;
        if (_basePos == new Vector2(-10000, -1000))
        {
            _basePos = transform.position;
        }
        transform.position = Input.mousePosition;
    }

    public void Drop(Transform transform)
    {
        _drag = false;
        transform.position = _basePos;
        ResetPos();
    }
}