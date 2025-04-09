using UnityEngine;
using UnityEngine.InputSystem;

namespace ProtagScripts
{
    public class ProtagInput : MonoBehaviour
    {
        [Header("Config")]

        public Vector2 MovementInput => movementInput;

        private Vector2 movementInput;

        public void SetInput(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }
    }
}