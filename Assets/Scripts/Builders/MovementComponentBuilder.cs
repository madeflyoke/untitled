using Builders.Interfaces;
using Components.Movement;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.AI;

namespace Builders
{
    public class MovementComponentBuilder : IBuilder<MovementComponent>
    {
        private Preset _navMeshAgentPreset;
        private GameObject _navMeshAgentHolder;
        
        public MovementComponentBuilder ApplyNavMeshAgentPreset(GameObject holder, Preset navMeshAgentPreset)
        {
            _navMeshAgentHolder = holder;
            _navMeshAgentPreset = navMeshAgentPreset;
            return this;
        }

        public MovementComponent Build()
        {
            var navMeshAgent = _navMeshAgentHolder.AddComponent<NavMeshAgent>();
            _navMeshAgentPreset.ApplyTo(navMeshAgent);
            return new MovementComponent(navMeshAgent);
        }
    }
}
