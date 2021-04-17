using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text gameOverLabel;
    [SerializeField] private AudioClip gameOverAudioClip;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(BallController.Instance.GetBallCount());
        BallController.Instance.SetBallCount(BallController.Instance.GetBallCount()-1);
        
        if (other.gameObject.CompareTag("Ball") && BallController.Instance.GetBallCount() == 0)
        {
            AudioSource.PlayClipAtPoint(gameOverAudioClip, Camera.main.transform.position);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverLabel.text = $"GAME OVER ASDASDASD {PlayerPrefs.GetString("name")}";
            totalScoreText.text = $"Total Score: {ScoreController.Instance.GetScore().ToString()}";
        }
    }
}
