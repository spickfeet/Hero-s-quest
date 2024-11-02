using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Container : MonoBehaviour, IContainer
{
    private IItem _item;
    public IItem Item => _item;

    [SerializeField] private ContainerType _type;
    public ContainerType Type => _type;

    [SerializeField] private List<ContainerSprite> _containerSprites;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CollectItem(IItem item)
    {
        if (_item == null || _item.Type == ItemType.Empty)
        {
            _item = item;

            ChangeSprite(_item.Type);
        }
    }

    public void RemoveItem()
    {
        if (_item != null)
        {
            _item = new Item(ItemType.Empty);

            ChangeSprite(_item.Type);
        }
    }

    private void ChangeSprite(ItemType itemType)
    {
        foreach (ContainerSprite containerSprite in _containerSprites)
        {
            if (containerSprite.ItemType == itemType)
            {
                _spriteRenderer.sprite = containerSprite.Sprite;
            }
        }
    }
}
