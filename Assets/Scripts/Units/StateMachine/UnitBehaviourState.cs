using System;

namespace Units.StateMachine
{
    public abstract class UnitBehaviourState : IDisposable, IState
    {
        public abstract IState Initialize();
        
        public abstract void Enter();

        public abstract void Exit();
        
        public void Dispose()
        {
        }
    }
}
