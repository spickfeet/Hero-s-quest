using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D), typeof(EventTrigger))]
public class Ingredient : MonoBehaviour
{
    [SerializeField] private ItemType _item;
    private Selection _selection;
    private void Awake()
    {
        _selection = FindAnyObjectByType<Selection>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IMinigameWorkStation minigameWorkStation = collision.GetComponent<IMinigameWorkStation>();
        if (minigameWorkStation != null)
        {
            minigameWorkStation.Add(_item);
            StartCoroutine(Delete());
        }
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log(_selection.CurrentTransform.position);
        Debug.Log(transform.position);
        Debug.Log(_selection.CurrentTransform.position == transform.position);
        
        if (_selection.Drag == false || _selection.CurrentTransform.position == transform.position) 
        {
            Destroy(this.gameObject);
            _selection.ResetPos();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
