using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    private Slider slider;
    private float value;
    [SerializeField] private Image icon;
    [SerializeField] private Sprite[] spriteIcon;
    [SerializeField] AudioSource MusicTema;

    void Start()
    {
        slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("VolumeMusic"))
        {
            value = PlayerPrefs.GetFloat("VolumeMusic");
            slider.value = value;
        }
        else
        {
            value = 1;
            slider.value = value;
        }
        onMusicSetting();
    }

    public void SetValue()
    {
        value = slider.value;
        onMusicSetting();
    }

    public void onMusicSetting()
    {
        MusicTema.volume = value;
        SaveVolumeMusic();
        if (value == 0)
        {
            icon.sprite = spriteIcon[0];
        }
        else
        {
            icon.sprite = spriteIcon[1];
        }
    }
    private void SaveVolumeMusic()
    {
        PlayerPrefs.SetFloat("VolumeMusic", value);
    }
}
