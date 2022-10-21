using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SwichToggleIsTimeBar : SwichTogle
{
    public bool isTimeBar;

    private void Start()
    {
        toggle.isOn = isTimeBar;
        SelectToggleTimeBar();
    }

    public void SelectToggleTimeBar()
    {
        isTimeBar = toggle.isOn;
        OnToggleClick();
    }

}
