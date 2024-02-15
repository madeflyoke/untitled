using System;
using Interfaces;

namespace Components.StateMachine.States.Units.Base
{
    public abstract class UnitBehaviourState : IDisposable, IState
    {
        protected global::Components.StateMachine.StateMachine StateMachine { get; }

        protected UnitBehaviourState(global::Components.StateMachine.StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void Exit();
        
        public void Dispose()
        {
        }
    }
}
