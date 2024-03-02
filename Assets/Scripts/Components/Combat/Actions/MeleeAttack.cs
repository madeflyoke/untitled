using System;
using BehaviorDesigner.Runtime.Tasks;
using Components.Animation;
using Components.Animation.Enums;
using Components.Animation.Interfaces;
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
            CallOnAnimation?.Invoke(this, AnimationClipData);
        }

        private void SetFinished()
        {
            _finished = true;
        }

        public override void OnAnimationCallback(IAnimationCaller caller, AnimationEventType eventType)
        {
            base.OnAnimationCallback(caller, eventType);
            switch (eventType)
            {
                case AnimationEventType.END:
                    SetFinished();
                    break;
            }
        }
    }
}
