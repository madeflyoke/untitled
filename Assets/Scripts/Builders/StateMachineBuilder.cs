using System;
using System.Collections.Generic;
using Builders.Interfaces;
using Components.StateMachine;
using Components.StateMachine.States.Units;
using Interfaces;

namespace Builders
{
    public class StateMachineBuilder: IBuilder<StateMachine>
    {
        private readonly Dictionary<Type, IState> _states;
        private readonly StateMachine _stateMachine;
        
        public StateMachineBuilder()
        {
            _states = new();
            _stateMachine = new(_states);
        }
        
        public StateMachineBuilder AddIdleState()
        {
            _states.Add(typeof(UnitIdleState), new UnitIdleState(_stateMachine));
            return this;
        }
        //
        // public StateMachineBuilder AddChasingState()
        // {
        //     _states.Add(typeof(UnitChasingState), new UnitChasingState(_stateMachine, ));
        //     return this;
        // }

        public StateMachine Build()
        {
            return new StateMachine(_states);
        }
    }
}
