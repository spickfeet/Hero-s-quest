using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Container : MonoBehaviour, IContainer
{
    [SerializeField] private ItemType _item;
    public ItemType Item => _item;

    [SerializeField] private ContainerType _type;
    public ContainerType Type => _type;

    [SerializeField] private List<ContainerSprite> _containerSprites;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        ChangeSprite(_item);
    }

    public void CollectItem(ItemType item)
    {
        _item = item;

        ChangeSprite(_item);
    }

    public void RemoveItem()
    {
        _item = ItemType.Empty;

        ChangeSprite(_item);
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
