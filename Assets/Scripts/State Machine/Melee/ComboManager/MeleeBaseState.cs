using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State_Machine.Melee.ComboManager
{
    public class MeleeBaseState : State
    {
        public float Duration;
        
        protected Animator Animator;

        protected bool ShouldCombo;
        
        protected int AttackCounter;

        public override void OnEnter(StateMachine _stateMachine)
        {
            base.OnEnter(_stateMachine);
            Animator = GetComponent<Animator>();
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShouldCombo = true;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
    
}
