using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProtagScripts
{
    /// <summary>
    ///     Top-level class for the protags
    /// </summary>
    public class Protag : MonoBehaviour
    {

        [Header("Depends")]

        [SerializeField]
        private Transform stringPoint;

        public Vector3 StringPosition => stringPoint.position;
        
        private static int remainingPlayers = 2;
        private bool active;

        public void Start()
        {
            active = true;
        }

        public void SetDefeated(bool defeated)
        {
            if(defeated)
            {

                transform.Find("Input").gameObject.SetActive(false);
                remainingPlayers -=1;
                active = false;
                if (remainingPlayers == 0)
                {
                    Invoke(nameof(RestartScene), 2f);
                }
            }
            else
            {
                active = true;
                transform.Find("Input").gameObject.SetActive(true);
                remainingPlayers +=1;
            }
        }

        // Use this for physical collisions (if not using triggers)
        private void OnCollisionEnter2D(Collision2D collision)
        {
            print(1);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                print(2);
                SetDefeated(true);
            }
            if (collision.transform.parent.gameObject.GetComponent<Protag>().active == false)
            {
                print(3);
                collision.transform.parent.gameObject.GetComponent<Protag>().SetDefeated(false);
            }
        }
        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}