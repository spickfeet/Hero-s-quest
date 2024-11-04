using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameBowl : MinigameWorkStation
{
    [SerializeField] private int _needCountMixing;
    private int _currentCountMixing = 0;

    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;

    [SerializeField] private List<GameObject> _ingredientInBowl;
    private Dictionary<ItemType, int> _indexByType;

    private void Awake()
    {
        _indexByType = new()
        {
            {ItemType.Flour, 0},
            {ItemType.Egg, 1},
            {ItemType.Sugar, 0},
            {ItemType.CreamCheese, 1},
            {ItemType.HeavyCream, 2},
        };


        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        if (_needItems.Count == 0)
        {
            _currentCountMixing++;
            _audioManager.PlaySFX(_audioClips[_ingredientInBowl.Count - 1]);
            if (_currentCountMixing >= _needCountMixing)
            {
                _ingredientInBowl[_ingredientInBowl.Count - 1].SetActive(true);
                OnFinished?.Invoke(_resultItem);
            }
        }
    }

    public override void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _needItems.Remove(item);
            _audioManager.PlaySFX(_audioClips[_indexByType[item]]);
            _ingredientInBowl[_indexByType[item]].SetActive(true);
        }
    }
}
