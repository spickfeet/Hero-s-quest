using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    private Player _player;
    public void Interact()
    {
    }

    public void Inject(Player player)
    {
        _player = player;
    }
}
