using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameBowl : MinigameWorkStation
{
    [SerializeField] private int _needCountMixing;
    private int _currentCountMixing = 0;

    [SerializeField] private List<ItemType> _needItems;

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
            _currentCountMixing++;
            if (_currentCountMixing >= _needCountMixing)
            {
                OnFinished?.Invoke();
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
