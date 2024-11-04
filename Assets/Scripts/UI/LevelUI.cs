using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    [SerializeField] private string _sceneName;

    private void OnEnable()
    {
        _timer.TimeEnded += OnTimerEnded;
    }

    private void OnDisable()
    {
        _timer.TimeEnded -= OnTimerEnded;
    }

    private void OnTimerEnded()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
