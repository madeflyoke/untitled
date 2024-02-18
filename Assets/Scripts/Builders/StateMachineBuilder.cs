using System;
using System.Collections.Generic;
using Builders.Interfaces;
using Components.StateMachine;
using Components.StateMachine.States.Units;
using Interfaces;
using UnityEngine.AI;

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
        
        public StateMachineBuilder AddChasingState(NavMeshAgent agent)
        {
            _states.Add(typeof(UnitChasingState), new UnitChasingState(_stateMachine, agent));
            return this;
        }

        public StateMachine Build()
        {
            return _stateMachine;
        }
    }
}
