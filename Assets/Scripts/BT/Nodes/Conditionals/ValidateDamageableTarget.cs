using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BT.Shared;
using UnityEngine;

namespace BT.Nodes.Conditionals
{
    public class ValidateDamageableTarget : Conditional
    {
        private SharedDamageable _targetDamageable;
        private SharedTransform _targetTransform;
        
        public void SetSharedVariables(SharedDamageable targetDamageable, SharedTransform targetTransform)
        {
            _targetDamageable = targetDamageable;
            _targetTransform = targetTransform;
        }

        public override TaskStatus OnUpdate()
        {
            return ValidateTransform() && ValidateDamageable() ? TaskStatus.Success : TaskStatus.Failure;
        }

        private bool ValidateDamageable()
        {
            return _targetDamageable.Value.IsAlive;
        }

        private bool ValidateTransform()
        {
            return _targetTransform.Value != null;
        }
    }
}
