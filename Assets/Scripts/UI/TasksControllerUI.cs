using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksControllerUI : MonoBehaviour
{
    private WorkStation[] _workStations;
    private Text[] _tasks;
    private Dictionary<ItemType,int> _tasksID;

    private void Awake()
    {
        _tasksID = new Dictionary<ItemType, int>()
        {
              { ItemType.Dough, 0},
              { ItemType.Flour, 1},
              { ItemType.Egg, 2},
              { ItemType.Form, 3},
              { ItemType.SlicedStrawberries, 4},
              { ItemType.Cream, 5},
              { ItemType.HeavyCream, 6},
              { ItemType.CreamCheese, 7},
              { ItemType.Sugar, 8},
              { ItemType.Cake, 9}
        };




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
