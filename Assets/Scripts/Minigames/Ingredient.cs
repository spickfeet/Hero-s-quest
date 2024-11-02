using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D), typeof(EventTrigger))]
public class Ingredient : MonoBehaviour
{
    [SerializeField] private ItemType _item;
    private Vector2 _basePos;

    private void Awake()
    {
        _basePos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IMinigameWorkStation minigameWorkStation = collision.GetComponent<IMinigameWorkStation>();
        if (minigameWorkStation != null)
        {
            minigameWorkStation.Add(_item);
        }
    }
}
