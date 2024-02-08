using System;
using Units.Base;

namespace Units.StateMachine
{
    public abstract class UnitBehaviourState : IDisposable, IState
    {
        public virtual IState Initialize()
        {
            return this;
        }
        
        public abstract void Enter();

        public abstract void Exit();
        
        public void Dispose()
        {
        }
    }
}
