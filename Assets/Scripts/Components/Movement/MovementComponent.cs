using Components.Interfaces;
using UnityEngine.AI;

namespace Components.Movement
{
    public class MovementComponent : IEntityComponent
    {
        public NavMeshAgent Agent { get; }
        
        public MovementComponent(NavMeshAgent agent)
        {
            Agent = agent;
        }
    }
}
