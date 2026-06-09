using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterView))]
    [RequireComponent(typeof(PlayerAnimator))]

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _movingSpeed = 5f;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private InputService _inputService;
        [SerializeField] private GroundChecker _groundChecker;

        private Rigidbody2D _rigidbody;
        private CharacterView _view;
        private PlayerAnimator _playerAnimator;

        private bool _isGrounded;

        public bool DeathState { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _view = GetComponent<CharacterView>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Update()
        {
            Move();
            Jump();
            UpdateAnimationState();
        }

        private void FixedUpdate()
        {
            _isGrounded = _groundChecker.IsGroundDetected();
        }

        private void Move()
        {
            float moveInput = _inputService.HorizontalInput;

            transform.position += Vector3.right * moveInput * _movingSpeed * Time.deltaTime;

            if (moveInput != 0)
            {
                _view.SetDirection(moveInput);
            }
        }

        private void Jump()
        {
            if (_inputService.JumpPressed == false)
                return;

            if (_isGrounded == false)
               return;

            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void UpdateAnimationState()
        {
            if (_isGrounded == false)
            {
                _playerAnimator.PlayJump();
            }
            else if (_inputService.HorizontalInput != 0)
            {
                _playerAnimator.PlayRun();
            }
            else
            {
                _playerAnimator.PlayIdle();
            }
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