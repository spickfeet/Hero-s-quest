using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private GameObject _settingsUI;

    [SerializeField] private Scroll _scroll;

    public void StartButton()
    {
        _scroll.gameObject.SetActive(true);
    }

    public void Settings()
    {
        _settingsUI.SetActive(true);
    }

    private void OnNewsEnded()
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void OnEnable()
    {
        _scroll.NewsEnded += OnNewsEnded;
    }

    private void OnDisable()
    {
        _scroll.NewsEnded -= OnNewsEnded;
    }
}
