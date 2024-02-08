using System;
using System.Collections.Generic;
using Units.Components.Interfaces;
using Units.StateMachine;

namespace Units.Components.StateMachine
{
    public class RangedStatesHolder : IStateHolder
    {
        public Dictionary<Type, IState> BehaviourStates { get; }
        
        public RangedStatesHolder()
        {
            BehaviourStates = new();
            BehaviourStates.Add(typeof(UnitIdleState), new UnitIdleState().Initialize());
            BehaviourStates.Add(typeof(UnitAttackState), new UnitAttackState().Initialize());
        }
    }
}
