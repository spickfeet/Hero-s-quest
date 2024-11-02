using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 3);
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
            }
        }

    }
}
