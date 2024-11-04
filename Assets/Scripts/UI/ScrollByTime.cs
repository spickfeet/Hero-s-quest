using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollByTime : Scroll
{
    private Timer _timer;

    public void Inject(Timer timer)
    {
        _timer = timer;
    }

    private void Update()
    {
        if (_timer == null) return;

        if (_news.Count <= 0) return;

        if (_timer.CurrentTime >= _news[0].TimeToStart)
        {
            SetNextNews();
        }
    }


}
