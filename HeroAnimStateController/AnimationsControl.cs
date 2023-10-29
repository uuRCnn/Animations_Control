using System;
using _Hereos;
using _States;
using UnityEngine;

namespace _Controllers
{
    public class AnimationsControl : MonoBehaviour
    {
        // ==> Components
        [SerializeField] private Animator animator;

        private HeroAnimStateController _heroAnimStateController;
        private HeroAnimState _walkAnimState;
        private HeroAnimState _idleAnimState;

        // ==> Enums
        private enum AnimationsEnum : byte
        {
            Idle,
            Walk,
        }
        
        // ==> Main Functions
        void AnimatoinsController(AnimationsEnum expression)
        {
            switch (expression)
            {
                case AnimationsEnum.Idle:
                    Idle();
                    break;
                case AnimationsEnum.Walk:
                    Walk();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(expression), expression, null);
            }
        }

        // ==> Unity Event Functions
        private void Awake()
        {
            _heroAnimStateController = new HeroAnimStateController(animator);
            _walkAnimState = new WalkAnimState(animator);
            _idleAnimState = new IdleAnimState(animator);
        }

        // ==> Litle Functions
        public void IdleAnim()
        {
            AnimatoinsController(AnimationsEnum.Idle);
        }

        public void WalkAnim()
        {
            AnimatoinsController(AnimationsEnum.Walk);
        }

        private void Idle()
        {
            if (!HeroMain.IsMoving)  // is Hero Moving check
                _heroAnimStateController.ChangeState(_idleAnimState);
        }

        private void Walk()
        {
            _heroAnimStateController.ChangeState(_walkAnimState);
        }
    }
}