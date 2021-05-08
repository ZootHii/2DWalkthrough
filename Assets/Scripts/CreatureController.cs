using System;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;
    
    private void Start()
    {
        direction = new Vector3(0, 1, 0);
    }

    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CreatureDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
