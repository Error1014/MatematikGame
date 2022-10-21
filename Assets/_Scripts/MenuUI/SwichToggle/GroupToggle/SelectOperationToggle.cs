using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOperationToggle : MonoBehaviour
{
    [SerializeField] private SetingsLevelHard settingsLevel;
    [SerializeField] public Toggle[] toggle;

    public bool isPlus;
    public bool isMinus;
    public bool isUmnoj;
    public bool isDelen;
    private void Start()
    {
        toggle[0].isOn = isPlus;
        toggle[1].isOn = isMinus;
        toggle[2].isOn = isUmnoj;
        toggle[3].isOn = isDelen;
    }
    public void ClickIsPlus()
    {
        isPlus = toggle[0].isOn;
    }
    public void ClicIsMinus()
    {
        isMinus = toggle[1].isOn;
    }
    public void ClickIsUmnoj()
    {
        isUmnoj = toggle[2].isOn;
    }
    public void ClicIsDelen()
    {
        isDelen = toggle[3].isOn;
    }
}
