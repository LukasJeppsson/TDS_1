using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public float invincibility = 1.0f;
    bool invinseble;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 6)
        {
            health = 5;
            Debug.Log("Player health: " + health);
        }
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