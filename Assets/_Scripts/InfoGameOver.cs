using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoGameOver : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text BestScoreText;
    void Start()
    {
        int Score = GameLogik.score;
        int bestScore = PlayerPrefs.GetInt("BestScore");
        ScoreText.text = ScoreText.text + " " + Score.ToString();
        BestScoreText.text = BestScoreText.text + " " + bestScore.ToString();
        if (Score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", Score);
        }
    }
}
