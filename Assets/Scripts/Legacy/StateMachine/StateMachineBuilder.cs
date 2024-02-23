using System;
using System.Collections.Generic;
using Builders.Interfaces;
using Interfaces;
using UnityEngine.AI;

namespace Legacy.StateMachine
{
    [Obsolete]
    public class StateMachineBuilder: IBuilder<StateMachine>
    {
        private readonly Dictionary<Type, IState> _states;
        private readonly StateMachine _stateMachine;
        
        public StateMachineBuilder()
        {
            _states = new();
            _stateMachine = new(_states);
        }
        
        public StateMachine Build()
        {
            return _stateMachine;
        }
    }
}
