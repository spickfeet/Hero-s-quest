using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    [SerializeField] private ScrollByCross _scroll;

    [SerializeField] private string _sceneName;

    private void OnEnable()
    {
        _scroll.NewsEnded += OnNewsEnded;
    }

    private void OnDisable()
    {
        _scroll.NewsEnded -= OnNewsEnded;
    }

    private void OnNewsEnded()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
