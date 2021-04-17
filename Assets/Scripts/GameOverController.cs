using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text gameOverLabel;
    [SerializeField] private AudioClip gameOverAudioClip;
    [SerializeField] private Text highScoreText1;
    [SerializeField] private Text highScoreText2;
    [SerializeField] private Text highScoreText3;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(BallController.Instance.GetBallCount());
        BallController.Instance.SetBallCount(BallController.Instance.GetBallCount()-1);
        
        if (other.gameObject.CompareTag("Ball") && BallController.Instance.GetBallCount() == 0)
        {
            AudioSource.PlayClipAtPoint(gameOverAudioClip, Camera.main.transform.position);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            ScoreController.Instance.SaveHighScore(ScoreController.Instance.GetScore());
            var scores = ScoreController.Instance.GetHighScoresList();
            
            highScoreText1.text = $"SCORE: {scores[0]}";
            highScoreText2.text = $"SCORE: {scores[1]}";
            highScoreText3.text = $"SCORE: {scores[2]}";
            /*for (int j = 0; j < scores.Count; j++)
            {
                int height = 3;
                var text = Instantiate(highScoreText);
                text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -height * j);
                //highScoreText2.text = $"SCORE: {score}";
                text.GetComponent<Text>().text = $"SCORE: {scores[j]}";
                Debug.Log("HİGHSCORES: "+ scores[j]);
            }*/
            Debug.Log(PlayerPrefs.GetString("name"));
            gameOverLabel.text = $"GAME OVER {PlayerPrefs.GetString("name")}";
            totalScoreText.text = $"Total Score: {ScoreController.Instance.GetScore().ToString()}";
        }
    }
}
