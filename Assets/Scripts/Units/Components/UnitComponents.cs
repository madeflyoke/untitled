using System;
using Sirenix.OdinInspector;
using Units.Base;
using Units.Configs;
using UnityEngine;
using UnityEngine.AI;

namespace Units.Components
{
    [Serializable]
    public class UnitComponents
    {
        public NavMeshAgent NavMeshAgent;
        [ReadOnly] public Unit Unit;
    }
}
