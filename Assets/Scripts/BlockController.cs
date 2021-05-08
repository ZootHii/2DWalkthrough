using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private AudioClip blockDestroyAudioClip;

    private void Start()
    {
        ScoreController.Instance.CountBlockAmount();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioSource.PlayClipAtPoint(blockDestroyAudioClip, Camera.main.transform.position);
            Destroy(gameObject);
            ScoreController.Instance.IncreaseScore();
        }
    }
}
