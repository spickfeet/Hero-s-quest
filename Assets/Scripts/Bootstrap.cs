using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Newspaper _newspaper;
    [SerializeField] private Player _player;

    [SerializeField] private Interactable[] _interactables;

    private void Awake()
    {
        _interactables = (Interactable[])FindObjectsByType(typeof(Interactable), FindObjectsSortMode.None);
    }

    private void Start()
    {
        _newspaper.Inject(_timer);

        foreach (Interactable interactable in _interactables)
        {
            interactable.Inject(_player);
        }
    }
}
