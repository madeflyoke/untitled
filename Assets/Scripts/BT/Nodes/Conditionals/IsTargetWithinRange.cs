using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BT.Nodes.Conditionals
{
    public class IsTargetWithinRange : Conditional
    {
        private SharedTransform _selfTransform;
        private SharedTransform _target;
        private float _range;
        
        public void SetSharedVariables(SharedTransform selfTransform, SharedTransform targetTransform, float range)
        {
            _selfTransform = selfTransform;
            _target = targetTransform;
            _range = range;
        }

        public override TaskStatus OnUpdate()
        {
            return IsWithinRange() ? TaskStatus.Success : TaskStatus.Failure;
        }

        private bool IsWithinRange()
        {
            return Vector3.Distance(_target.Value.position, _selfTransform.Value.position) <= _range;
        }
    }
}
