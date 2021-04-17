using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    [SerializeField] private Text textScore;
    private int score;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            Debug.Log(PlayerPrefs.GetInt("score"));
            score = PlayerPrefs.GetInt("score");
            textScore.text = score.ToString();
        }
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseScore(int amount = 1)
    {
        score += amount;
        textScore.text = score.ToString();
        if (SceneManager.GetActiveScene().name == "Level1" && score == 3)
        {
            PlayerPrefs.SetInt("score", score);
            SceneController.Instance.NextLevel(2);
        }
        else if (SceneManager.GetActiveScene().name == "Level2" && score == 6)
        {
            PlayerPrefs.SetInt("score", score);
            SceneController.Instance.NextLevel(3);
        }
    }
    
    public int GetScore()
    {
        return score;
    }
}
