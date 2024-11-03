using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameForm : MinigameWorkStation
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;

    private void Awake()
    {
        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        OnFinished?.Invoke(_resultItem);
        Debug.Log("OnFinished");
    }
}
