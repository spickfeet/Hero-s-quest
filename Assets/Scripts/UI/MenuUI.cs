using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private GameObject _settingsUI;

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Settings()
    {
        _settingsUI.SetActive(true);
    }
}
