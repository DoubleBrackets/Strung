using ProtagScripts;
using UnityEngine;

public class ProtagCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print(1);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // print(2);
            var protag = GetComponentInParent<Protag>();
            protag.SetDefeated(true);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            var protag = collision.gameObject.GetComponentInParent<Protag>();
            if (protag.IsDefeated())
            {
                // print(3);
                protag.SetDefeated(false);
            }
        }
    }
}