using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
    [SerializeField] private GameObject _paper;
    [SerializeField] private Image _image;
    [SerializeField] private Text _text;
    [SerializeField] private Button _button;

    [SerializeField] private List<News> _news;

    private Timer _timer;

    public void Inject(Timer timer)
    {
        _timer = timer;
        _button.onClick.AddListener(delegate { _paper.SetActive(false); });
    }

    private void Update()
    {
        if (_timer == null) return;

        if (_news.Count > 0)
        {
            if (_timer.CurrentTime >= _news[0].TimeToStart)
            {
                DisplayNews(_news[0]);

                _news.RemoveAt(0);
            }
        }
    }

    private void DisplayNews(News news)
    {
        _paper.SetActive(true);

        _image.sprite = news.Sprite;
        _text.text = news.Text;
    }
}