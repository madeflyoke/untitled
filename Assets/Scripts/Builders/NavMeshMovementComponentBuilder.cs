using Builders.Interfaces;
using Components.Animation.Interfaces;
using Components.Movement;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.AI;

namespace Builders
{
    public class NavMeshMovementComponentBuilder : IBuilder<NavMeshMovementComponent>
    {
        private readonly GameObject _componentsHolder;
        private Preset _navMeshAgentPreset;

        public NavMeshMovementComponentBuilder(GameObject componentsHolder)
        {
            _componentsHolder = componentsHolder;
        }
        
        public NavMeshMovementComponentBuilder ApplyNavMeshAgentPreset(Preset navMeshAgentPreset)
        {
            _navMeshAgentPreset = navMeshAgentPreset;
            return this;
        }

        public NavMeshMovementComponent Build()
        {
            var navMeshAgent = _componentsHolder.AddComponent<NavMeshAgent>();
            
            if (_navMeshAgentPreset!=null)
                _navMeshAgentPreset.ApplyTo(navMeshAgent);
            
            return new NavMeshMovementComponent(navMeshAgent);
        }
    }
}
