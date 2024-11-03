using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _radiusInteraction = 3;

    [SerializeField] private Container _container;
    public Container Container
    {
        get { return _container; }
        set { _container = value; }
    }

    [SerializeField] private Transform _itemAnchor;
    public Transform ItemAnchor => _itemAnchor;

    private void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _radiusInteraction);

        if (collider2Ds.Length <= 0) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(collider2Ds);
        }
    }
    private void Interact(Collider2D[] collider2Ds)
    {
        foreach (var collider2D in collider2Ds)
        {
            if (collider2D.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radiusInteraction);
    }
}
