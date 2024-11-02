using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Newspaper _newspaper;

    private void Start()
    {
        _newspaper.Inject(_timer);
    }
}
