using ProtagScripts;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    public Transform protagA;

    public Transform protagB;

    private Vector3 velocity;

    private Rigidbody2D rb2d;

    private Protag protagAScript;
    private Protag protagBScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        velocity = Vector3.zero;
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        protagAScript = protagA.GetComponentInParent<Protag>();
        protagBScript = protagB.GetComponentInParent<Protag>();
    }

    // Update is called once per frame
    private void Update()
    {
        // DONE:
        // Find nearest player
        // Run towards player

        // WIP:
        // If collision, destroy player

        Vector3 posPlayer1 = protagA.position;
        Vector3 posPlayer2 = protagB.position;
        Vector3 pos = gameObject.transform.position;
        Vector3 direction = Vector3.zero;

        Transform nearestPlayer = protagA;

        bool defeatedPlayer1 = protagAScript.IsDefeated();
        bool defeatedPlayer2 = protagBScript.IsDefeated();

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
                nearestPlayer = protagA;
            }
            else
            {
                nearestPlayer = protagB;
            }

            direction = nearestPlayer.position - pos;
        }

        velocity = Vector3.Lerp(velocity, direction.normalized, 1f / 2f * Time.deltaTime);
        rb2d.linearVelocity = velocity * speed;
    }
}