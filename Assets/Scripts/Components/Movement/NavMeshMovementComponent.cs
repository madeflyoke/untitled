using Components.Interfaces;
using UnityEngine.AI;

namespace Components.Movement
{
    public class NavMeshMovementComponent : IEntityComponent
    {
        public NavMeshAgent Agent { get; }
        
        public NavMeshMovementComponent(NavMeshAgent agent)
        {
            Agent = agent;
        }
    }
}
