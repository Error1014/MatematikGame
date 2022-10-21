using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SwichToggleIsOtric : SwichTogle
{
    public bool isOtric;

    private void Start()
{
        toggle.isOn = isOtric;
        SelectToggleOtricNumb();
    }

    public void SelectToggleOtricNumb()
    {
        isOtric = toggle.isOn;
        OnToggleClick();
    }
}
