using System;
using Units.Base;
using Units.Components;

namespace Units.StateMachine
{
    public abstract class UnitBehaviourState : IDisposable, IState
    {
        protected UnitComponents Components { get; private set; }

        public virtual IState Initialize(UnitComponents components)
        {
            Components = components;
            return this;
        }
        
        public abstract void Enter();

        public abstract void Exit();
        
        public void Dispose()
        {
        }
    }
}
