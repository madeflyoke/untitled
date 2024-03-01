using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Utility;

namespace Components.Combat.Actions
{
    public class MeleeAttack : CombatAction
    {
        private bool _finished;
        
        public override TaskStatus GetCurrentStatus()
        {
            if (_finished)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }

        public override void Execute()
        {
            _finished = false;
            Debug.LogWarning("attack animation...");
            AnimationComponent.PlayCustomAnimation(AnimationNames.Combat, ActionAnimation);
            AnimationComponent.AnimationEventsListener.OnCurrentAnimationEnd += SetFinished;
        }

        private void SetFinished()
        {
            _finished = true;
            AnimationComponent.AnimationEventsListener.OnCurrentAnimationEnd -= SetFinished;
        }
    }
}
