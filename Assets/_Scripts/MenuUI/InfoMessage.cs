using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InfoMessage : MonoBehaviour

{
    [SerializeField] private Text textInfo;
    public void ShowInfo(string message)
    {
        textInfo.text = message;
    }

    public void CloseInfoMessage()
    {
        gameObject.SetActive(false);
    }
}
