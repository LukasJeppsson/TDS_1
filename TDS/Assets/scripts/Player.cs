using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float invincibility = 1.0f;
    bool invinseble;
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 screenBondery;
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 700.0f;
    public GameObject bullet;
    public GameObject gun;
    public float bulletSpeed = 21.0f;
    float targetAngel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBondery = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack()
    {
        GameObject playerBullet = Instantiate(bullet, gun.transform.position, transform.rotation);
        Rigidbody2D BulletRb = playerBullet.GetComponent<Rigidbody2D>();
        BulletRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        if (moveInput != Vector2.zero)
        {
            targetAngel = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBondery.x, screenBondery.x)
                                       , Mathf.Clamp(transform.position.y, -screenBondery.y, screenBondery.y));
        if (health >= 6)
        {
            health = 5;
        }
    }

    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngel - 90, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
    }

    void ResetInvinsibility()
    {
        invinseble = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies") && !invinseble)
        {
            if (health <= 1)
            {
                Destroy(gameObject);
            }
            else
            {
                health--;
                invinseble = true;
                Invoke("ResetInvinsibility", invincibility);
                Debug.Log("Player health: " + health);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OneHealth") && health <= 4)
        {
            health++;
            Debug.Log("Player health: " + health);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("TwoHealth") && health <= 4)
        {
            health += 2;
            Debug.Log("Player health: " + health);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Invinsibility"))
        {
            invinseble = true;
            Invoke("ResetInvinsibility", 3);
            Destroy(collision.gameObject);
        }

    }
}
