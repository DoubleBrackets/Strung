using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    
    float spawnChance = 1f; // 0 to 1
    float spawnInterval = 1f;
    float spawnTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            // print(1);
            spawnTimer = spawnInterval;
            float chance = Random.Range(0f, 1f);
            if (chance <= spawnChance) {
                
                // print(2);
                Vector2 rectMin = new Vector2(-5f, -5f);
                Vector2 rectMax = new Vector2(5f, 5f);

                float randomX = Random.Range(rectMin.x, rectMax.x);
                float randomY = Random.Range(rectMin.y, rectMax.y);

                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

        } 
    }
}
