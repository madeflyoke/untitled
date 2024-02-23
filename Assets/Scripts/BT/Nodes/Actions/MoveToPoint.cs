using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.AI;

namespace BT.Nodes.Actions
{
    public class MoveToPoint : Action
    {
        private SharedVector3 _targetPoint;
        private NavMeshAgent _agent;

        public void SetSharedVariables(SharedVector3 targetPoint)
        {
            _targetPoint = targetPoint;
        }
        
        public MoveToPoint Initialize(NavMeshAgent agent)
        {
            _agent = agent;
            return this;
        }
        
        public override TaskStatus OnUpdate()
        {
            _agent.destination = _targetPoint.Value;
            
            return TaskStatus.Success;
        }
    }
}
