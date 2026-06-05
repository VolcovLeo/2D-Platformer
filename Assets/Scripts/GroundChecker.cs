using UnityEngine;

namespace Platformer
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundPoint;
        [SerializeField] private float _groundDetectionRadius = 0.2f;

        public bool IsGroundDetected()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundPoint.position, _groundDetectionRadius);

            return colliders.Length > 1;
        }
    }
}
