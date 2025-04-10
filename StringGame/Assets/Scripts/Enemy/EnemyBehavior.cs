using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Vector3 direction;
    
    [SerializeField]
    private float speed = 10f;
    
    public Transform player1;
    public Transform player2;
    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player1Object = GameObject.Find("Player1");
        player1 = player1Object.transform.Find("Body");
        
        GameObject player2Object = GameObject.Find("Player2");
        player2 = player2Object.transform.Find("Body");

        direction = Vector3.zero;
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

        Transform nearestPlayer = player1;

        if ((posPlayer1 - pos).magnitude < (posPlayer2 - pos).magnitude)
        {
            nearestPlayer = player1;
        }
        else
        {
            nearestPlayer = player2;
        }

        Vector3 target = nearestPlayer.position;
        direction = Vector3.Lerp(direction, (target - pos).normalized, 1f/2f * Time.deltaTime);
        // gameObject.transform.position += direction * speed * Time.deltaTime;
        rb2d.linearVelocity = direction * speed;
    }
}
