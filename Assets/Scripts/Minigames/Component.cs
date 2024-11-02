using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Component : MonoBehaviour
{
    [SerializeField] private ItemType _item;
    private Vector2 _basePos;

    private void Awake()
    {
        _basePos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWorkStation bowl = collision.GetComponent<IWorkStation>();
        if (bowl != null)
        {
            bowl.Add(_item);
        }
    }
}
