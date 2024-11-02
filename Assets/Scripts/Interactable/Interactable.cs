using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    private Player _player;
    public virtual void Interact()
    {
    }

    public void Inject(Player player)
    {
        _player = player;
    }
}
