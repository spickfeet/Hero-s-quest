using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollByCross : Scroll
{
    protected override void CrossButton()
    {
        base.CrossButton();

        SetNextNews();
    }

    private void Start()
    {
        SetNextNews();
    }
}
