using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Animator))]

    public class PlayerAnimator : MonoBehaviour
    {
        private const string StateParameter = "playerState";

        private const int IdleState = 0;
        private const int RunState = 1;
        private const int JumpState = 2;

        private Animator _animator;

        private int _currentState = -1;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayIdle()
        {
            SetState(IdleState);
        }

        public void PlayRun()
        {
            SetState(RunState);
        }

        public void PlayJump()
        {
            SetState(JumpState);
        }

        private void SetState(int state)
        {
            if (_currentState == state)
                return;

            _currentState = state;
            _animator.SetInteger(StateParameter, state);
        }
    }
}