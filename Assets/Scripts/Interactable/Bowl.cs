using UnityEngine;


public class Bowl : Interactable
{
    [SerializeField] private WorkStation _workStation;
    [SerializeField] private GameObject _minigameWindow;

    private void Awake()
    {
        _workStation.OnFinished += Finish;
    }

    public void Finish()
    {
        _minigameWindow.SetActive(false);
    }

    public override void Interact()
    {
        _minigameWindow.SetActive(true);
    }
}

