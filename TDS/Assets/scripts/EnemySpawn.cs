using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 3.0f;

    float spanwDistans = 10.0f;
    Vector2 ScreenBounds;
    Vector2 spawnpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                spawnpos = new Vector2(Random.Range(-ScreenBounds.x, ScreenBounds.x), ScreenBounds.y + spanwDistans);
                break;
            case 1: spawnpos = new Vector2(Random.Range(-ScreenBounds.x, ScreenBounds.x), -ScreenBounds.y + -spanwDistans);
                break;
            case 2: 
                spawnpos = new Vector2(ScreenBounds.x + spanwDistans, Random.Range(-ScreenBounds.y, ScreenBounds.y));
                break;
            case 3:
                spawnpos = new Vector2(-ScreenBounds.x + -spanwDistans, Random.Range(-ScreenBounds.y, ScreenBounds.y));
                break;
        }
        Instantiate(enemyPrefab, spawnpos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
