using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameBoard : MinigameWorkStation
{

    [SerializeField] private int _needCountCutting;
    private int _currentCountCutting = 0;

    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;
    [SerializeField] private List<GameObject> _ingredientOnBoard;

    private void Awake()
    {
        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        if (_needItems.Count == 0)
        {
            _currentCountCutting++;
            _audioManager.PlaySFX(_audioClips[1]);
            if (_currentCountCutting >= _needCountCutting)
            {
                OnFinished?.Invoke(_resultItem);
                _ingredientOnBoard[0].SetActive(false);
                _ingredientOnBoard[1].SetActive(true);
            }
        }
    }

    public override void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _needItems.Remove(item);
            _audioManager.PlaySFX(_audioClips[0]);
            _ingredientOnBoard[0].SetActive(true);
        }
    }
}

