using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour, IWorkStation
{
    [SerializeField] private int _needCountMixing;
    private int _currentCountMixing = 0;

    [SerializeField] List<ItemType> _needItems;

    public Action OnFinished { get; set; }

    public void Cook()
    {
        if (_needItems.Count == 0)
        {
            _currentCountMixing++;
            if (_currentCountMixing >= _needCountMixing)
            {
                Debug.Log("OnFinished");
            }
        }
    }

    public void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _needItems.Remove(item);
        }
    }
}
