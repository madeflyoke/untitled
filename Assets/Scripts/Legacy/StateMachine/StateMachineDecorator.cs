using System;
using Interfaces;

namespace Legacy.StateMachine
{
    [Obsolete]
    public class StateMachineDecorator : IEntityDecorator
    {
        private readonly StateMachineBuilder _stateMachineBuilder;
        
        public StateMachineDecorator()
        {
            _stateMachineBuilder = new StateMachineBuilder();
        }

        public StateMachineDecorator AppendState<TState>() where TState : IState
        {
            //unfinished 
            return this;
        }
        
        public IEntity Decorate(IEntity entity)
        {
            var stateMachine = CreateStateMachine();
            entity.AddEntityComponent(stateMachine);
            return entity;
        }

        private StateMachine CreateStateMachine()
        {
            return _stateMachineBuilder.Build();
        }
    }
}
