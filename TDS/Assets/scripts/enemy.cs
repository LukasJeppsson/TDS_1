using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class enemy : MonoBehaviour
{
    Transform player;
    public float moveSpeed = 3.0f;
    Rigidbody2D rb;
    Vector2 direction;
    public float health = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        moveSpeed = Random.Range(6, 14);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            direction = (player.position - transform.position).normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            if (health <= 1)
            {
                Destroy(gameObject);
            }
            else
            {
                health--;
            }
        }
    }
}
