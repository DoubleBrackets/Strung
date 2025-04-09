using UnityEngine;

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
    }
}