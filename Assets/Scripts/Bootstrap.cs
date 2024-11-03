using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Newspaper _newspaper;
    [SerializeField] private Player _player;

    [SerializeField] private Interactable[] _interactables;

    [SerializeField] private TasksControllerUI _tasksControllerUI;
    private WorkStation[] _workStations;

    private void Awake()
    {
        _interactables = (Interactable[])FindObjectsByType(typeof(Interactable), FindObjectsSortMode.None);
        _workStations = (WorkStation[])FindObjectsByType(typeof(WorkStation), FindObjectsSortMode.None);

        _newspaper.Inject(_timer);

        foreach (Interactable interactable in _interactables)
        {
            interactable.Inject(_player);
        }
        _tasksControllerUI.Inject(_workStations);
    }
}
