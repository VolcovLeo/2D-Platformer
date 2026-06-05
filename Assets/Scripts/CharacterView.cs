using UnityEngine;

namespace Platformer
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private bool _spriteLooksRightByDefault;
        [SerializeField] private bool _lookRightOnStart = true;

        private const float DefaultRotationY = 0f;
        private const float FlippedRotationY = 180f;

        private void Start()
        {
            SetDirection(_lookRightOnStart ? 1f : -1f);
        }

        public void SetDirection(float direction)
        {
            if (direction == 0)
                return;

            bool shouldLookRight = direction > 0;

            if (_spriteLooksRightByDefault)
            {
                transform.rotation = Quaternion.Euler(0f, shouldLookRight ? DefaultRotationY : FlippedRotationY, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, shouldLookRight ? FlippedRotationY : DefaultRotationY, 0f);
            }
        }
    }
}