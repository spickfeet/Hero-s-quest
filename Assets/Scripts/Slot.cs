using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : Interactable
{
    [SerializeField] private Transform _anchor;

    [SerializeField] private Container _container;

    public override void Interact()
    {
        if (_container is null && _player.Container is null) return;

        if (_player.Container is null)
        {
            _player.Container = _container;
            Debug.Log(_player.Container);
            _container.transform.SetParent(_player.ItemAnchor);
            Debug.Log("container.transform.SetParent(_player.ItemAnchor);");
            _container.transform.localPosition = Vector3.zero;

            _container = null;
        }
        else
        {
            if (_container is null)
            {
                _container = _player.Container;
                _container.transform.SetParent(_anchor);
                _container.transform.localPosition = Vector3.zero;
                _player.Container = null;
            }
        }
    }
}
