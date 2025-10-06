using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject oneHealth;
    public GameObject twoHealth;
    public GameObject invinsibility;

    public float itemSpawnTimeMax = 15;
    public float itemSpawnTimeMin = 10;
    float itemSpawnTime;
    int spawnItemMax = 4;
    int spawnItemMin = 1;
    float spawnItem;
    Vector2 ScreenBounds;
    Vector2 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
    {
        itemSpawnTime = Random.Range(itemSpawnTimeMin, itemSpawnTimeMax);
        spawnItem = Random.Range(spawnItemMin, spawnItemMax);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spawnPos = new Vector2(Random.Range(-ScreenBounds.x, ScreenBounds.x), Random.Range(-ScreenBounds.y, ScreenBounds.y));
        if (spawnItem == 1)
        {
            Instantiate(oneHealth, spawnPos, transform.rotation);
        }
        else if (spawnItem == 2)
        {
            Instantiate(twoHealth, spawnPos, transform.rotation);
        }
        else if (spawnItem == 3)
        {
            Instantiate(invinsibility, spawnPos, transform.rotation);
        }

            Invoke("SpawnItem", itemSpawnTime);
    }
}
