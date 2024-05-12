using System;
using UnityEngine;

namespace State_Machine
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState { get; private set; } 
        private State _nextState;

        private void Update()
        {
            if (_nextState != null)
            {
                SetState(_nextState);
                _nextState = null;
            }
            
            if (CurrentState != null)
            {
                CurrentState.OnUpdate();
            }
        }
        
        private void SetState(State _newState)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }
            
            CurrentState = _newState;
            CurrentState.OnEnter(this);
        }
        
        public void ChangeState(State _newState)
        {
            if (_newState != null)
            {
                _nextState = _newState;    
            }
            
        }
    }
}