using UnityEngine;

namespace Platformer
{
    public class InputService : MonoBehaviour
    {
        public float HorizontalInput { get; private set; }

        public bool JumpPressed { get; private set; }

        private void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            JumpPressed = Input.GetKeyDown(KeyCode.Space);
        }

        private void LateUpdate()
        {
            JumpPressed = false;
        }
    }
}
