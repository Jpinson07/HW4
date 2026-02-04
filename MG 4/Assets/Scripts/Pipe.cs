using UnityEngine;
using System;

public class Pipe : MonoBehaviour
{
    public static event Action OnPipePassed;

    [SerializeField] private float moveSpeed = 2f;
    private bool hasScored = false;

    void Update()
    {
    
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

    
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player passed through the gap
        if (!hasScored && collision.CompareTag("Player"))
        {
            hasScored = true;
            OnPipePassed?.Invoke();
        }
    }
}
