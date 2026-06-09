using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(EnemyTargetDetector))]

    public class EnemyChaser : MonoBehaviour
    {
        private EnemyTargetDetector _detector;

        public bool CanSeePlayer => _detector.HasTarget;

        private void Awake()
        {
            _detector = GetComponent<EnemyTargetDetector>();
        }

        public Transform GetPlayer()
        {
            return _detector.Target != null ? _detector.Target.transform : null;
        }
    }
}
