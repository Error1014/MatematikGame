using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameLogik : MonoBehaviour
{
    public static int score;
    [SerializeField] private Text textScote;
    [SerializeField] private GameObject Info;
    //public static UnityEvent RestartGames = new UnityEvent();

    private void Start()
    {
        Time.timeScale = 1;
        score = 0;
        textScote.text = "0";
        ButtonVariant.StartClickEvent.AddListener(AddScore);
        ButtonVariant.NoRightClickEvent.AddListener(GameOver);
        TimeBar.EndTimeEvnt.AddListener(GameOver);
    }
    public void AddScore()
    {
        score++;
        ShowScore();
    }
    private void ShowScore()
    {
        textScote.text = score.ToString();
    }

    public void GameOver()
    {
        Info.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
