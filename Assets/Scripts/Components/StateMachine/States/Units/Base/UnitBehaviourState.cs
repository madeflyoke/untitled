using System;
using Interfaces;

namespace Components.StateMachine.States.Units.Base
{
    public abstract class UnitBehaviourState : IDisposable, IState
    {
        protected StateMachine StateMachine { get; }

        protected UnitBehaviourState(StateMachine stateMachine)
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
