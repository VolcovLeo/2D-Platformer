using UnityEngine;

namespace Platformer
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform leftPoint;
        [SerializeField] private Transform rightPoint;
        [SerializeField] private float speed = 2f;

        private Transform target;

        private void Start()
        {
            target = rightPoint;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.05f)
            {
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            target = target == leftPoint ? rightPoint : leftPoint;
        }
    }
}
