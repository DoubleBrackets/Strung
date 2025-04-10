using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform protagA;

    [SerializeField]
    private Transform protagB;

    [SerializeField]
    private Vector2 spawnRadiusRange;

    [SerializeField]
    private Vector2 spawnIntervalRange;

    /// <summary>
    ///     minimum distance from the protags to spawn an enemy
    /// </summary>
    [SerializeField]
    private float minRadius;

    public GameObject enemyPrefab;

    // Adjust these to your liking
    private float spawnChance = 0f; // Should start at 0, slowly lerps to 1
    private float spawnTimer;
    private float startTimer = 4f; // Added a start timer so people can get used to controls

    // Update is called once per frame
    private void Update()
    {
        startTimer -= Time.deltaTime;
        if (startTimer <= 0f)
        {
            spawnChance += (1f - spawnChance) * 1f / 16f * Time.deltaTime;
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                spawnTimer = Random.Range(spawnIntervalRange.x, spawnIntervalRange.y);
                float chance = Random.Range(0f, 1f);
                if (chance <= spawnChance)
                {
                    // print(spawnChance);
                    Vector2 spawnPosition = Random.insideUnitCircle * Random.Range(spawnRadiusRange.x, spawnRadiusRange.y);

                    Vector2 posPlayer1 = protagA.position;
                    Vector2 posPlayer2 = protagB.position;

                    while ((posPlayer1 - spawnPosition).magnitude < minRadius ||
                        (posPlayer2 - spawnPosition).magnitude < minRadius)
                    {
                        spawnPosition = Random.insideUnitCircle * Random.Range(spawnRadiusRange.x, spawnRadiusRange.y);
                    }

                    GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    var enemyScript = enemy.GetComponent<EnemyBehavior>();
                    enemyScript.protagA = protagA;
                    enemyScript.protagB = protagB;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Vector3.zero, spawnRadiusRange.x);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector3.zero, spawnRadiusRange.y);
    }
}