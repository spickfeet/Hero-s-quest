using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Scroll : MonoBehaviour
{
    [SerializeField] protected GameObject _paper;
    [SerializeField] protected Image _image;
    [SerializeField] protected Text _text;
    [SerializeField] protected Button _button;

    [SerializeField] protected List<News> _news;

    public UnityAction NewsEnded;

    protected void Awake()
    {
        _button.onClick.AddListener(CrossButton);
    }

    protected virtual void CrossButton()
    {
        _paper.SetActive(false);
    }

    protected virtual void DisplayNews(News news)
    {
        _paper.SetActive(true);

        _image.sprite = news.Sprite;
        _text.text = news.Text;
    }

    protected void SetNextNews()
    {
        if (_news.Count <= 0)
        {
            NewsEnded?.Invoke();

            return;
        }

        DisplayNews(_news[0]);

        _news.RemoveAt(0);
    }
}