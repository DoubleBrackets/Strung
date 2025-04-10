using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ProtagScripts
{
    /// <summary>
    ///     Top-level class for the protags
    /// </summary>
    public class Protag : MonoBehaviour
    {
        private static int remainingPlayers;

        [Header("Depends")]

        [SerializeField]
        private Transform stringPoint;

        [Header("Events")]

        [SerializeField]
        private UnityEvent OnDefeated;

        [SerializeField]
        private UnityEvent OnRevived;

        public Vector3 StringPosition => stringPoint.position;
        private bool active;

        public void Start()
        {
            active = true;
            remainingPlayers = 2;
        }

        public bool IsDefeated()
        {
            return active == false;
        }

        public void SetDefeated(bool defeated)
        {
            if (active && defeated)
            {
                OnDefeated?.Invoke();
                remainingPlayers -= 1;
                active = false;
                if (remainingPlayers <= 0)
                {
                    Invoke(nameof(RestartScene), 2f);
                }
            }
            else if (active == false && defeated == false)
            {
                active = true;
                OnRevived?.Invoke();
                remainingPlayers += 1;
            }
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}