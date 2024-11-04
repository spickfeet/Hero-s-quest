using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameFurnace : MinigameWorkStation
{
    [SerializeField] private int _needCountFire;
    private int _currentCountFire = 0;

    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;
    [SerializeField] private List<GameObject> _ingredientsInFurnace;

    private void Awake()
    {
        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        if (_needItems.Count == 0)
        {
            _audioManager.PlaySFX(_audioClips[1]);
            _currentCountFire++;
            if (_currentCountFire >= _needCountFire)
            {
                _ingredientsInFurnace[0].SetActive(false);
                _ingredientsInFurnace[1].SetActive(true);
                OnFinished?.Invoke(_resultItem);
            }
        }
    }

    public override void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _audioManager.PlaySFX(_audioClips[0]);
            _needItems.Remove(item);
            _ingredientsInFurnace[0].SetActive(true);
        }
    }
}

