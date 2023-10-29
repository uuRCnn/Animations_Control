using UnityEngine;

namespace _States
{
    public abstract class HeroAnimState
    {
        // ==> Components
        protected readonly Animator Animator;

        protected HeroAnimState(Animator animator)
        {
            this.Animator = animator;
        }

        // ==> Abstract Functions
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }

    public class IdleAnimState : HeroAnimState
    {
        public IdleAnimState(Animator animator) : base(animator)
        {
        }

        // ==> Abstract Functions
        public override void OnEnter()
        {
            Animator.Play("Idle");
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }

    public class WalkAnimState : HeroAnimState
    {
        public WalkAnimState(Animator animator) : base(animator)
        {
        }

        // ==> Abstract Functions
        public override void OnEnter()
        {
            Animator.Play("Walk");
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }
    }

    /// <summary>
    /// Hero Animasyonlarını burdan çekerek kontrol et.
    /// </summary>
    // ==> Main Functions
    public class HeroAnimStateController
    {
        // ==> Components
        private HeroAnimState _currentState;

        public HeroAnimStateController(Animator animator)
        {
            _currentState = new IdleAnimState(animator);
            _currentState.OnEnter();
        }

        // ==> Main Functions
        public void ChangeState(HeroAnimState newState)
        {
            if (_currentState == newState)
                return;

            _currentState.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }

        public void Update()
        {
            _currentState.OnUpdate();
        }
    }
}