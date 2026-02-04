using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDied;
    public static event Action OnPlayerFlapped;

    [SerializeField] private float jumpStrength = 7f;

    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      


    }

    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            GameOver.Instance.EndGame();
        }

        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);

           
            OnPlayerFlapped?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.collider.CompareTag("Pipe"))
        {
            isDead = true;
            Debug.Log("PLAYER DIED");
            
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;

            
            OnPlayerDied?.Invoke();
        }
        if (collision.collider.CompareTag("Pipe"))
        {
            GameOver.Instance.EndGame();
        }
    }
}


