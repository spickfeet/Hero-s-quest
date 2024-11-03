using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksControllerUI : MonoBehaviour
{
    private WorkStation[] _workStations;
    [SerializeField] private Text[] _tasks;
    private Dictionary<ItemType,int> _tasksID;

    private void Awake()
    {
        _tasksID = new Dictionary<ItemType, int>()
        {
              { ItemType.Dough, 0},
              { ItemType.Flour, 1},
              { ItemType.Egg, 2},
              { ItemType.Form, 3},
              { ItemType.ReadyDough, 4},
              { ItemType.SlicedStrawberries, 5},
              { ItemType.Strawberry, 6},
              { ItemType.Cream, 7},
              { ItemType.HeavyCream, 8},
              { ItemType.CreamCheese, 9},
              { ItemType.Sugar, 10},
              { ItemType.Cake, 11}
        };
    }

    private void Start()
    {
        foreach (WorkStation workStation in _workStations)
        {
            workStation.OnTaskComplete += TaskComplete;
        }
    }

    public void Inject(WorkStation[] workStations)
    {
        _workStations = workStations;
    }

    public void TaskComplete(ItemType item)
    {
        _tasks[_tasksID[item]].color = Color.green;
    }
}
