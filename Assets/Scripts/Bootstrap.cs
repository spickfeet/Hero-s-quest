using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Newspaper _newspaper;
    [SerializeField] private Player _player;
    private Slot[] _slots;

    private void Awake()
    {
        _slots = (Slot[])FindObjectsByType(typeof(Slot), FindObjectsSortMode.None);
    }

    private void Start()
    {
        _newspaper.Inject(_timer);

        foreach (Slot slot in _slots)
        {
            slot.Inject(_player);
        }
    }
}
