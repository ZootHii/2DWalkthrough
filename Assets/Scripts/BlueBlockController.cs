using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockController : MonoBehaviour
{
    [SerializeField] private AudioClip blueBlockDestroyAudioClip;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioSource.PlayClipAtPoint(blueBlockDestroyAudioClip, Camera.main.transform.position);
            ScoreController.Instance.IncreaseScore(2);
            BallController.Instance.IncreaseBallAmount();
            Destroy(gameObject);
        }
    }
}
