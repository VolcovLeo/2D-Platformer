using UnityEngine;

namespace Platformer
{
    public class InputService : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        public float HorizontalInput { get; private set; }
        public bool JumpPressed { get; private set; }

        private void Update()
        {
            HorizontalInput = Input.GetAxisRaw(HorizontalAxis);
            JumpPressed = Input.GetKeyDown(KeyCode.Space);
        }
    }
}
