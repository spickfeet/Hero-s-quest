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
    [SerializeField] private List<GameObject> _cakeSegments;
    private Dictionary<ItemType, int> _indexByType;

    private void Awake()
    {
        _indexByType = new()
        {
            {ItemType.ReadyDough, 0 },
            {ItemType.Cream, 1 },
            {ItemType.SlicedStrawberries, 2 }
        };
        _button.onClick.AddListener(delegate { _window.SetActive(false); });
    }

    public override void Cook()
    {
        if (_needItems.Count == 0)
        {
            OnFinished?.Invoke(_resultItem);
        }
    }

    public override void Add(ItemType item)
    {
        if (_needItems.Contains(item))
        {
            _cakeSegments[_indexByType[item]].SetActive(true);
            _needItems.Remove(item);
            _audioManager.PlaySFX(_audioClips[0]);
            Cook();
        }
    }
}
