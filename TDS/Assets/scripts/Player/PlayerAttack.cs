using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;
    public float bulletSpeed = 21.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAttack()
    {
        GameObject playerBullet = Instantiate(bullet, gun.transform.position, transform.rotation);
        Rigidbody2D BulletRb = playerBullet.GetComponent<Rigidbody2D>();
        BulletRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
