using UnityEngine;


public class WorkStation : Interactable
{
    [SerializeField] private MinigameWorkStation _minigameWorkStation;
    [SerializeField] private GameObject _minigameWindow;

    private bool _isFinished;

    private void Awake()
    {
        _isFinished = false;
        _minigameWorkStation.OnFinished += Finish;
    }

    public void Finish()
    {
        _minigameWindow.SetActive(false);
        _isFinished = true;
        _minigameWorkStation.OnFinished -= Finish;
    }

    public override void Interact()
    {
        if (_isFinished == false)
        {
            _minigameWindow.SetActive(true);
        }
    }
}

