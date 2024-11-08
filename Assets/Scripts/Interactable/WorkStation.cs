﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WorkStation : Interactable
{
    [SerializeField] private ItemType _resultItem;
    [SerializeField] private MinigameWorkStation _minigameWorkStation;
    [SerializeField] private GameObject _minigameWindow;
    [SerializeField] private Selection _selection;

    [SerializeField] private List<ItemType> _needItems;

    [SerializeField] private List<ItemType> _needItemsCopy;

    [SerializeField] private GameObject _resultPref;

    public Action<ItemType> OnTaskComplete;

    private bool _isFinished;

    private void Awake()
    {
        _needItemsCopy = new List<ItemType>(_needItems);
        _isFinished = false;
        _minigameWorkStation.OnFinished += Finish;
    }

    public void Finish(ItemType item)
    {
        GameObject go = Instantiate(_resultPref);
        _player.Container = go.GetComponent<Container>();
        go.transform.SetParent(_player.ItemAnchor);
        _player.Container.transform.localPosition = new Vector2(0,0);
        _player.Container.CollectItem(item);


        OnTaskComplete.Invoke(item);
        _isFinished = true;
        _minigameWorkStation.OnFinished -= Finish;
        StartCoroutine(FinishCoroutine());
    }

    public IEnumerator FinishCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _minigameWindow.SetActive(false);
        _selection.ResetPos();
        if (_resultItem == ItemType.Cake) 
        {
            StartCoroutine(StartFinalScene());
        }


    }

    private IEnumerator StartFinalScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GoodEnding");
    }

    public override void Interact()
    {;
        if (_player.Container != null)
        {
            if (_needItemsCopy.Contains(_player.Container.Item))
            {
                OnTaskComplete.Invoke(_player.Container.Item);
                _needItemsCopy.Remove(_player.Container.Item);
                Destroy(_player.Container.gameObject);
                _player.Container = null;
            }
        }
        else
        {
            if (_isFinished == false && _needItemsCopy.Count == 0)
            {
                _minigameWindow.SetActive(true);
            }
        }    
    }
    public void Inject(AudioManager audioManager)
    {
        _minigameWorkStation.Inject(_needItems, _resultItem, audioManager);
    }
}

