using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class MinigameCake : MinigameWorkStation
{

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
            OnFinished?.Invoke(_resultItem);
            Debug.Log("OnFinished");
        }
    }

    public override void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _needItems.Remove(item);
            Cook();
        }
    }
}
