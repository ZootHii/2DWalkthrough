using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    [SerializeField] private Text textScore;
    private int score;
    private int blockAmount;
    private int blueBlockAmount;
    
    private List<int> highScores = new List<int>();


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
        
        //PlayerPrefs.DeleteAll();
        //SaveHighScore(3);
    }

    public void IncreaseScore(int amount = 1)
    {
        score += amount;
        if (score % 6 == 0)
        {
            BallController.Instance.IncreaseBallSpeed(0.5f);
        }
        int lastScore = 0;
        if (PlayerPrefs.HasKey("score"))
        {
            lastScore = PlayerPrefs.GetInt("score");
        }
        textScore.text = score.ToString();
        if (SceneManager.GetActiveScene().name == "Level1" && score == blockAmount + blueBlockAmount * 2 + lastScore) // blue blocks gives 2 score
        {
            PlayerPrefs.SetInt("score", score);
            SceneController.Instance.NextLevel(2);
        }
        else if (SceneManager.GetActiveScene().name == "Level2" && score == blockAmount + blueBlockAmount * 2 +lastScore)
        {
            PlayerPrefs.SetInt("score", score);
            SceneController.Instance.NextLevel(3);
        }
        else if (SceneManager.GetActiveScene().name == "Level3" && score == blockAmount + blueBlockAmount * +lastScore)
        {
            Debug.Log("WON");
            SceneManager.LoadScene("Start");
        }
    }

    public void CountBlockAmount()
    {
        blockAmount++;
    }
    
    public void CountBlueBlockAmount()
    {
        blueBlockAmount++;
    }
    
    public int GetScore()
    {
        return score;
    }

    public List<int> GetHighScoresList()
    {
        if (PlayerPrefs.HasKey("highscores"))
        {
            string getHighScoresJSON = PlayerPrefs.GetString("highscores");
            var fromJsonHighScores = JsonUtility.FromJson<HighScores>(getHighScoresJSON);
            return fromJsonHighScores.HighScoreList;
        }

        return new List<int>();
    }
    
    public void SaveHighScore(int highScore)
    {
        if (PlayerPrefs.HasKey("highscores"))
        {
            string getHighScoresJSON = PlayerPrefs.GetString("highscores");
            var fromJsonHighScores = JsonUtility.FromJson<HighScores>(getHighScoresJSON);
            
            if (fromJsonHighScores.HighScoreList.Count >= 3)
            {
                fromJsonHighScores.HighScoreList.RemoveAt(0);
            }
            
            highScores = fromJsonHighScores.HighScoreList;
            highScores.Add(highScore);
            var highScoresClass = new HighScores {HighScoreList = highScores};
            string json = JsonUtility.ToJson(highScoresClass);
            PlayerPrefs.SetString("highscores", json);
        }
        else
        {
            highScores.Add(highScore);
            var highScoresClass = new HighScores
            {
                HighScoreList = highScores
            };
            
            string toJsonHighScores = JsonUtility.ToJson(highScoresClass);
            PlayerPrefs.SetString("highscores", toJsonHighScores);
        }
    }
    
    [Serializable]
    public class HighScores
    {
        public List<int> HighScoreList;
    }
}
