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
            remainingPlayers == 2;
        }

        public bool IsDefeated()
        {
            return active == false;
        }
        public void SetDefeated(bool defeated)
        {
            if (active == true && defeated == true)
            {

                transform.Find("Input").gameObject.SetActive(false);
                transform.Find("Body").Find("Sprite").gameObject.SetActive(false);
                transform.Find("Body").Find("SpriteDisabled").gameObject.SetActive(true);
                remainingPlayers -=1;
                active = false;
                if (remainingPlayers <= 0)
                {
                    Invoke(nameof(RestartScene), 2f);
                }
            }
            else if (active == false && defeated == false)
            {
                active = true;
                transform.Find("Input").gameObject.SetActive(true);
                transform.Find("Body").Find("Sprite").gameObject.SetActive(true);
                transform.Find("Body").Find("SpriteDisabled").gameObject.SetActive(false);
                remainingPlayers +=1;
            }
        }
        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}