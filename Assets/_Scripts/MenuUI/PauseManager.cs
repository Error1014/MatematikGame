using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausPanel;
    public void OnPause()
    {
        if (Time.timeScale==1.0f)
        {
            Time.timeScale = 0f;
            PausPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            PausPanel.SetActive(false);
        }
    }
    public void NavigateHome()
    {
        SceneManager.LoadScene("SelectLobbyScene");
    }
}
