using UnityEngine;

namespace ProtagScripts
{
    public class BasicMovement : MonoBehaviour
    {
        [Header("Depends")]

        [SerializeField]
        private Rigidbody2D rb2d;

        [SerializeField]
        private ProtagInput input;

        [Header("Movement")]

        [SerializeField]
        private float speed;

        [SerializeField]
        private float accel;

        [SerializeField]
        private float defeatedSpeed;

        private bool canMove = true;

        private void Update()
        {
            Vector2 inputVector = input.MovementInput;

            float desireSpeed = canMove ? speed : defeatedSpeed;

            Vector2 targetVelocity = inputVector.normalized * desireSpeed;
            Vector2 velocity = rb2d.linearVelocity;

            velocity = Vector2.MoveTowards(velocity, targetVelocity, accel * Time.deltaTime);

            rb2d.linearVelocity = velocity;
        }

        public void SetMovingEnabled(bool enabled)
        {
            canMove = enabled;
        }
    }
}