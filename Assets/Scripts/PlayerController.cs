using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterView))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movingSpeed = 5f;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private InputService _inputService;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private CharacterView _view;

        private bool _isGrounded;

        public bool DeathState { get; private set; }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _view = GetComponent<CharacterView>();
        }

        private void Update()
        {
            float moveInput = _inputService.HorizontalInput;

            transform.position += new Vector3(moveInput, 0f, 0f) * _movingSpeed * Time.deltaTime;

            UpdateAnimation(moveInput);

            if (_inputService.JumpPressed && _isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

            if (moveInput != 0)
            {
                _view.SetDirection(moveInput);
            }
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void UpdateAnimation(float moveInput)
        {
            if (_animator == null)
                return;

            if (_isGrounded == false)
            {
                _animator.SetInteger("playerState", 2);
            }
            else if (moveInput != 0)
            {
                _animator.SetInteger("playerState", 1);
            }
            else
            {
                _animator.SetInteger("playerState", 0);
            }
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, 0.2f);

            _isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                DeathState = true;
            }
        }
    }
}