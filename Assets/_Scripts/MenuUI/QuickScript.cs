using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickScript : MonoBehaviour
{
    [SerializeField] GameObject MessageCloseGame;
    public void ShowMessageCloseApp()
    {
        MessageCloseGame.SetActive(!MessageCloseGame.active);
        
    }
    public void CloseApp()
    {
        Application.Quit();
    }
    public void CloseMessage()
    {
        MessageCloseGame.SetActive(false);
    }
}
