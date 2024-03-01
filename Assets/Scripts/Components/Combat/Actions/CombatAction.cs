using System;
using System.Linq;
using BehaviorDesigner.Runtime.Tasks;
using BT.Interfaces;
using Components.Animation;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace Components.Combat.Actions
{
    [Serializable]
    public abstract class CombatAction : IBehaviorAction
    {
        [field: SerializeField, OnValueChanged(nameof(ValidateAnimation))] protected AnimationClip ActionAnimation { get; }
        protected AnimationComponent AnimationComponent { get; private set; }
        
        public void Initialize(AnimationComponent animationComponent)
        {
            AnimationComponent = animationComponent;
        }
        
        public abstract TaskStatus GetCurrentStatus();
        public abstract void Execute();

#if UNITY_EDITOR
        
        public void ValidateAnimation()
        {
            AnimationUtility.SetAnimationEvents(ActionAnimation, Array.Empty<AnimationEvent>());
            AddEvent(nameof(AnimationEventsListener.OnAnimationStart), 0f);
            AddEvent(nameof(AnimationEventsListener.OnAnimationEnd), ActionAnimation.length);

            void AddEvent(string name, float time)
            {
                var animEvent = new AnimationEvent();
                animEvent.functionName = name;
                animEvent.time = time;
                AnimationUtility.SetAnimationEvents(ActionAnimation, ActionAnimation.events.Concat(new []{animEvent}).ToArray());
                EditorUtility.SetDirty(ActionAnimation);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
#endif
       
    }
}