using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwichTogle : MonoBehaviour
{
    [SerializeField] public Toggle toggle;
    [SerializeField] protected Image ToggleImage;
    [SerializeField] protected Sprite onSprite;
    [SerializeField] protected Sprite offSprite;
    [SerializeField] protected Image BackgroundImage;
    [SerializeField] protected Sprite onBackgroundSprite;
    [SerializeField] protected Sprite offBackgroundSprite;



    public void OnToggleClick()
    {
        ToggleImage.sprite = toggle.isOn ? onSprite : offSprite;    
        BackgroundImage.sprite = toggle.isOn ? onBackgroundSprite : offBackgroundSprite;
    }
}
