using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(CharacterView))]
    [RequireComponent(typeof(EnemyChaser))]

    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;
        [SerializeField] private float _speed = 2f;

        private CharacterView _view;
        private EnemyChaser _chaser;

        private Transform _target;

        private void Awake()
        {
            _view = GetComponent<CharacterView>();
            _chaser = GetComponent<EnemyChaser>();
        }

        private void Start()
        {
            _target = _rightPoint;
        }

        private void Update()
        {
            if (_chaser.CanSeePlayer)
            {
                MoveTo(_chaser.GetPlayer());
            }
            else
            {
                Patrol();
            }
        }

        private void Patrol()
        {
            MoveTo(_target);

            float distanceSquared = (_target.position - transform.position).sqrMagnitude;

            if (distanceSquared < 0.01f)
            {
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            if (_target == _leftPoint)
            {
                _target = _rightPoint;
            }
            else
            {
                _target = _leftPoint;
            }
        }

        private void MoveTo(Transform target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            _view.SetDirection(direction.x);
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }
    }
}
