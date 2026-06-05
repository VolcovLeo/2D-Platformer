using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(CharacterView))]

    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _rightPoint;
        [SerializeField] private float _speed = 2f;

        private CharacterView _view;
        private Transform _target;

        private void Start()
        {
            _view = GetComponent<CharacterView>();
            _target = _rightPoint;
        }

        private void Update()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _view.SetDirection(direction.x);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            float distance = (_target.position - transform.position).sqrMagnitude;

            if (distance < 0.01f)
            {
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            _target = _target == _leftPoint ? _rightPoint : _leftPoint;
        }
    }
}
