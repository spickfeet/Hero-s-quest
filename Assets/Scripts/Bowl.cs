using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField] private int _needCountMixing;
    private int _currentCountMixing;

    public Action OnFinished;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mix()
    {
        _currentCountMixing++;
        if (_currentCountMixing == _needCountMixing)
        {
            Debug.Log("OnFinished");
        }
    }

    public void Add()
    {
        
    }
}
