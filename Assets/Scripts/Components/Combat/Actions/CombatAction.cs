using System;
using BehaviorDesigner.Runtime.Tasks;
using BT.Interfaces;
using Components.Animation;
using Components.Animation.Enums;
using Components.Animation.Interfaces;
using UnityEngine;

namespace Components.Combat.Actions
{
    [Serializable]
    public abstract class CombatAction : IBehaviorAction, IAnimationCaller
    {
        public Action<IAnimationCaller, AnimationClipData> CallOnAnimation { get; set; }

        [field: SerializeField] public AnimationClipData AnimationClipData { get; }
        
        public virtual void OnAnimationCallback(IAnimationCaller caller, AnimationEventType eventType)
        {
            if (caller!=this)
            {
                return;
            }
        }
       
        public abstract TaskStatus GetCurrentStatus();
        public abstract void Execute();
        
       
    }
}