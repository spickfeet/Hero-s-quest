using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameFurnace : MinigameWorkStation
{
    [SerializeField] private int _needCountFire;
    private int _currentCountFire = 0;

    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;

    private void Awake()
    {
        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        if (_needItems.Count == 0)
        {
            _currentCountFire++;
            if (_currentCountFire >= _needCountFire)
            {
                OnFinished?.Invoke(_resultItem);
                Debug.Log("OnFinished");
            }
        }
    }

    public override void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _needItems.Remove(item);
        }
    }
}

