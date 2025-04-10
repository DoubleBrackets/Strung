using UnityEngine;
using ProtagScripts;

public class ProtagCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print(1);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // print(2);
            Protag protag = gameObject.transform.parent.parent.gameObject.GetComponent<Protag>();
            protag.SetDefeated(true);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Protag protag = collision.transform.parent.gameObject.GetComponent<Protag>();
            if (protag.IsDefeated())
            {
                // print(3);
                protag.SetDefeated(false);
            }
        }
    }
}
