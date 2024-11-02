using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeToFinish;

    private float _time;
    public float CurrentTime => _timeToFinish - _time;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        _time = _timeToFinish;
    }

    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            _text.text = ((int)_time).ToString();
        }
    }
}
