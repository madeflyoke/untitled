using System;
using System.Collections.Generic;
using Components.Interfaces;
using Interfaces;

namespace Components.StateMachine
{
    public class StateMachine : IEntityComponent
    {
        private IState _currentState;
        private readonly Dictionary<Type, IState> _states;

        public StateMachine(Dictionary<Type, IState> states)
        {
            _states = states;
        }

        public void SwitchState<TState>() where TState : IState
        {
            var newState = _states[typeof(TState)];

            if (newState==null || _currentState==newState)
            {
                return;
            }
            
            _currentState?.Exit();
            
            _currentState = newState;
            
            _currentState.Enter();
        }
    }
}