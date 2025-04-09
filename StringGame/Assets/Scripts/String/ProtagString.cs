using ProtagScripts;
using UnityEngine;
using UnityEngine.Events;

namespace String
{
    /// <summary>
    ///     Handles the string visual appearance between two protags
    /// </summary>
    public class ProtagString : MonoBehaviour
    {
        [Header("Depends")]

        [SerializeField]
        private Protag protagA;

        [SerializeField]
        private Protag protagB;

        [Header("Visuals")]

        [SerializeField]
        private LineRenderer lineRendererA;

        [SerializeField]
        private LineRenderer lineRendererB;

        [SerializeField]
        private Transform centerPoint;

        [Header("Stats")]

        [SerializeField]
        private float maxDistance;

        [Header("Collision")]

        [SerializeField]
        private LayerMask collisionLayer;

        [Header("Events")]

        [SerializeField]
        private UnityEvent onStringHit;

        private Vector2 midpoint;
        private Vector2 midpointVelocity;

        private void Update()
        {
            if (protagA == null || protagB == null)
            {
                return;
            }

            Vector2 p1 = protagA.StringPosition;
            Vector2 p2 = protagB.StringPosition;
            Vector2 newMidpoint = (p1 + p2) / 2;

            midpointVelocity = (newMidpoint - midpoint) / Time.deltaTime;

            midpoint = newMidpoint;

            UpdateStringVisuals(p1, p2);

            StringRaycast(p1, p2);
        }

        private void OnDrawGizmos()
        {
            if (protagA == null || protagB == null)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(midpoint, maxDistance / 2);
        }

        private void UpdateStringVisuals(Vector2 p1, Vector2 p2)
        {
            SetLineRenPos(lineRendererA, p1, midpoint);
            SetLineRenPos(lineRendererB, p2, midpoint);

            if (centerPoint != null)
            {
                centerPoint.position = midpoint;
            }
        }

        private void StringRaycast(Vector2 p1, Vector2 p2)
        {
            Vector2 direction = (p2 - p1).normalized;
            float distance = Vector2.Distance(p1, p2);
            RaycastHit2D[] hits = Physics2D.RaycastAll(p1, direction, distance, collisionLayer);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    var collidable = hit.collider.GetComponentInParent<IStringCollidable>();
                    if (collidable != null)
                    {
                        var data = new StringHitData
                        {
                            hitDirection = midpointVelocity.normalized
                        };
                        collidable.OnStringHit(data);

                        onStringHit?.Invoke();
                    }
                }
            }
        }

        private void SetLineRenPos(LineRenderer lineRenderer, Vector2 p1, Vector2 p2)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, p1);
            lineRenderer.SetPosition(1, p2);
        }
    }
}