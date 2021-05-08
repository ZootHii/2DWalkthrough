using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public static GameOverController Instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text gameOverLabel;
    [SerializeField] private AudioClip gameOverAudioClip;
    [SerializeField] private Text highScoreText1;
    [SerializeField] private Text highScoreText2;
    [SerializeField] private Text highScoreText3;
    public bool isGameOver;

    private void Awake()
    {
        Instance = this;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log(BallController.Instance.GetBallCount());
            BallController.Instance.SetBallCount(BallController.Instance.GetBallCount()-1);
        }

        if (other.CompareTag("Ball") && other.name.Contains("clone"))
        {
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Ball") && BallController.Instance.GetBallCount() == 0)
        {
            isGameOver = true;
            AudioSource.PlayClipAtPoint(gameOverAudioClip, Camera.main.transform.position);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            ScoreController.Instance.SaveHighScore(ScoreController.Instance.GetScore());
            var scores = ScoreController.Instance.GetHighScoresList();
            scores.Sort();
            scores.Reverse();
            foreach (int score in scores)
            {
                Debug.Log("SCOREs"+ score);
            }
            switch (scores.Count)
            {
                case 0:
                    highScoreText1.text = "SCORE: 0";
                    highScoreText2.text = "MAX SCORE: 0";
                    highScoreText3.text = "SCORE: 0";
                    break;
                case 1:
                    highScoreText1.text = "SCORE: 0";
                    highScoreText2.text = $"MAX SCORE: {scores[0]}";
                    highScoreText3.text = "SCORE: 0";
                    break;
                case 2:
                    highScoreText1.text = $"SCORE: {scores[1]}";
                    highScoreText2.text = $"MAX SCORE: {scores[0]}";
                    highScoreText3.text = "SCORE: 0";
                    break;
                default:
                    highScoreText1.text = $"SCORE: {scores[1]}";
                    highScoreText2.text = $"MAX SCORE: {scores[0]}";
                    highScoreText3.text = $"SCORE: {scores[2]}";
                    break;
            }
            Debug.Log(PlayerPrefs.GetString("name"));
            gameOverLabel.text = $"GAME OVER {PlayerPrefs.GetString("name")}";
            totalScoreText.text = $"Total Score: {ScoreController.Instance.GetScore().ToString()}";
        }
    }
}
