using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
