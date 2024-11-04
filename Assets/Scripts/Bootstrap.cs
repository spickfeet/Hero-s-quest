using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ScrollByTime _scroll;
    [SerializeField] private Player _player;
    [SerializeField] private AudioManager _audioManager;

    [SerializeField] private TasksControllerUI _tasksControllerUI;

    private Interactable[] _interactables;
    private WorkStation[] _workStations;

    private void Awake()
    {
        _interactables = (Interactable[])FindObjectsByType(typeof(Interactable), FindObjectsSortMode.None);
        _workStations = (WorkStation[])FindObjectsByType(typeof(WorkStation), FindObjectsSortMode.None);

        _scroll.Inject(_timer);

        foreach (Interactable interactable in _interactables)
        {
            interactable.Inject(_player);
        }
        _tasksControllerUI.Inject(_workStations);
        foreach (WorkStation workStation in _workStations)
        {
            workStation.Inject(_audioManager);
        }
        _player.Inject(_audioManager);
    }
}
