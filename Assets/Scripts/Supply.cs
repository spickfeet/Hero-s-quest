using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Supply : Interactable
{
    [SerializeField] private ContainerType _containerType;
    [SerializeField] private ItemType _itemType;

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
        if (_player.Container is null) return;

        if (_containerType == _player.Container.Type)
        {
            if (_player.Container.Item == ItemType.Empty)
            {
                _player.Container.CollectItem(_itemType);
                _itemType = ItemType.Empty;
                ChangeSprite(_itemType);
            }
        }
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
