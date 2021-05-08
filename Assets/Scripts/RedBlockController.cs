using UnityEngine;

public class RedBlockController : MonoBehaviour
{
    [SerializeField] private AudioClip redBlockDestroyAudioClip;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioSource.PlayClipAtPoint(redBlockDestroyAudioClip, Camera.main.transform.position);
        }
    }
}