using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BT.Shared;
using Extensions;
using Interfaces;
using UnityEngine;

namespace BT.Nodes.Actions
{
    public class FindClosestDamageableTarget : Action
    {
        private SharedDamageable _closestTargetDamageable;
        private SharedTransform _closestTargetTransform;

        private SharedTransform _selfTransform;
        
        private Dictionary<Transform, IDamageable> _targets;

        public FindClosestDamageableTarget Initialize(Dictionary<Transform, IDamageable> targets)
        {
            _targets = targets;
            return this;
        }
        
        public void SetSharedVariables(SharedTransform selfTransform, SharedDamageable resultTargetDamageable, SharedTransform resultTargetTransform)
        {
            _selfTransform = selfTransform;
            _closestTargetDamageable = resultTargetDamageable;
            _closestTargetTransform = resultTargetTransform;
        }

        public override TaskStatus OnUpdate()
        {
            if (UpdateTargets())
            {
                _closestTargetTransform.Value = _selfTransform.Value.GetClosestTransform(_targets.Keys);
                _closestTargetDamageable.Value = _targets[_closestTargetTransform.Value];
                return TaskStatus.Success;
            }

            return TaskStatus.Failure;
        }

        private bool UpdateTargets()
        {
            if (_targets.Count!=0)
            {
                _targets = _targets
                    .Where(pair => pair.Key != null && pair.Value.IsAlive)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            return _targets.Count != 0;
        }


    }
}
