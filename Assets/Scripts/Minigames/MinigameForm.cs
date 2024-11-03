using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameForm : MinigameWorkStation
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;
    [SerializeField] private GameObject _doughInForm;

    private void Awake()
    {
        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        _doughInForm.SetActive(true);
        OnFinished?.Invoke(_resultItem);
    }
}
