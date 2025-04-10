using UnityEngine;
using ProtagScripts;

public class EnemyBehavior : MonoBehaviour
{
    Vector3 velocity;
    
    [SerializeField]
    private float speed = 10f;
    GameObject player1Object;
    GameObject player2Object;
    private Transform player1;
    private Transform player2;
    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1Object = GameObject.Find("Player1");
        player1 = player1Object.transform.Find("Body");
        
        player2Object = GameObject.Find("Player2");
        player2 = player2Object.transform.Find("Body");

        velocity = Vector3.zero;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // DONE:
        // Find nearest player
        // Run towards player

        // WIP:
        // If collision, destroy player

        Vector3 posPlayer1 = player1.position;
        Vector3 posPlayer2 = player2.position;
        Vector3 pos = gameObject.transform.position;
        Vector3 direction = Vector3.zero;

        Transform nearestPlayer = player1;

        bool defeatedPlayer1 = player1Object.GetComponent<Protag>().IsDefeated();
        bool defeatedPlayer2 = player2Object.GetComponent<Protag>().IsDefeated();
        
        if (defeatedPlayer1 && defeatedPlayer2)
        {
            Vector3 randomDirection = Random.onUnitSphere;
        }
        else if (defeatedPlayer1)
        {
            direction = posPlayer2 - pos;
        }
        else if (defeatedPlayer2)
        {
            direction = posPlayer1 - pos;
        }
        else
        {
            if ((posPlayer1 - pos).magnitude < (posPlayer2 - pos).magnitude)
            {
                nearestPlayer = player1;
            }
            else
            {
                nearestPlayer = player2;
            }
            direction = nearestPlayer.position - pos;
        }

        velocity = Vector3.Lerp(velocity, direction.normalized, 1f/2f * Time.deltaTime);
        rb2d.linearVelocity = velocity * speed;
    }
}
