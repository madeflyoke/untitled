using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Components.Interfaces
{
    public interface IStateHolder 
    {
        public Dictionary<Type, IState> BehaviourStates { get; }
    }
}
