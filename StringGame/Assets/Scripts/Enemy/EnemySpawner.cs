using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    
    private Transform player1;
    private Transform player2;

    // Adjust these to your liking
    float spawnChance = 1f; // Should start at 0, slowly lerps to 1
    float spawnInterval = 1f;
    float spawnTimer = 0f;

    float minRadius = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player1Object = GameObject.Find("Player1");
        player1 = player1Object.transform.Find("Body");
        
        GameObject player2Object = GameObject.Find("Player2");
        player2 = player2Object.transform.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        spawnChance += (1f - spawnChance) * 1f/128f * Time.deltaTime;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            spawnTimer = spawnInterval;
            float chance = Random.Range(0f, 1f);
            if (chance <= spawnChance) {
                // print(spawnChance);
                
                Vector2 rectMin = new Vector2(-14f, -14f);
                Vector2 rectMax = new Vector2(14f, 14f);

                float randomX = Random.Range(rectMin.x, rectMax.x);
                float randomY = Random.Range(rectMin.y, rectMax.y);

                Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

                Vector3 posPlayer1 = player1.position;
                Vector3 posPlayer2 = player2.position;

                while ((posPlayer1 - spawnPosition).magnitude < minRadius || (posPlayer2 - spawnPosition).magnitude < minRadius)
                {
                    randomX = Random.Range(rectMin.x, rectMax.x);
                    randomY = Random.Range(rectMin.y, rectMax.y);

                    spawnPosition = new Vector3(randomX, randomY, 0);
                }
                
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

        } 
    }
}
