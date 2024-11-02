using System.Collections;
using UnityEngine;


public class WorkStation : Interactable
{
    [SerializeField] private MinigameWorkStation _minigameWorkStation;
    [SerializeField] private GameObject _minigameWindow;
    [SerializeField] private Selection _selection;

    private bool _isFinished;

    private void Awake()
    {
        _isFinished = false;
        _minigameWorkStation.OnFinished += Finish;
    }

    public void Finish()
    {
        _isFinished = true;
        _minigameWorkStation.OnFinished -= Finish;
        StartCoroutine(FinishCoroutine());
    }

    public IEnumerator FinishCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        _minigameWindow.SetActive(false);
        _selection.ResetPos();
    }

    public override void Interact()
    {
        if (_isFinished == false)
        {
            _minigameWindow.SetActive(true);
        }
    }
}

