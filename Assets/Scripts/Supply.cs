using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Supply : Interactable
{
    [SerializeField] private ContainerType _containerType;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private GameObject _resultPref;

    [SerializeField] private List<SupplySprite> _supplySprites;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeSprite(_itemType);
    }

    public override void Interact()
    {
        if (_player.Container != null || _itemType == ItemType.Empty) return;

        GameObject go = Instantiate(_resultPref);
        _player.Container = go.GetComponent<Container>();
        go.transform.SetParent(_player.ItemAnchor);
        _player.Container.transform.localPosition = new Vector2(0, 0);
        _player.Container.CollectItem(_itemType);

        _itemType = ItemType.Empty;
        ChangeSprite(_itemType);

    }

    private void ChangeSprite(ItemType itemType)
    {
        foreach (var supply in _supplySprites)
        {
            if (supply.Type == itemType)
            {
                _spriteRenderer.sprite = supply.Sprite;
            }
        }
    }
}
