using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed = 5f;
        public float jumpForce = 5f;

        private float moveInput;
        private bool facingRight = false;
        private bool isGrounded;

        [HideInInspector]
        public bool deathState = false;

        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(moveInput, 0, 0) * movingSpeed * Time.deltaTime;

            if (animator != null)
            {
                if (!isGrounded)
                    animator.SetInteger("playerState", 2); 
                else if (moveInput != 0)
                    animator.SetInteger("playerState", 1); 
                else
                    animator.SetInteger("playerState", 0); 
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (moveInput > 0 && !facingRight)
                Flip();
            else if (moveInput < 0 && facingRight)
                Flip();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void Flip()
        {
            facingRight = facingRight == false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                deathState = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Coin"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}