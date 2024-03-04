using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Utility;

namespace Components.Animation
{
    [Serializable]
    public class AnimationClipData
    {
        [field: SerializeField, OnValueChanged(nameof(ValidateAnimation))] public AnimationClip AnimationClip { get; private set; }
        [field: SerializeField, ValueDropdown(nameof(GetNames))] public string TargetStateName { get; private set; }
        [field: SerializeField] public float TransitionDuration { get; private set; }= 0.25f ;

        public AnimationClipData(AnimationClip animationClip = default, string targetStateName = default, float transitionDuration = 0.25f)
        {
            AnimationClip = animationClip;
            TargetStateName = targetStateName ?? AnimatorStatesNames.Idle;
            TransitionDuration = transitionDuration;
        }
        
#if UNITY_EDITOR
        
        public void ValidateAnimation()
        {
            AnimationUtility.SetAnimationEvents(AnimationClip, Array.Empty<AnimationEvent>());
            AddEvent(nameof(AnimationEventsListener.OnAnimationStart), 0f);
            AddEvent(nameof(AnimationEventsListener.OnAnimationEnd), AnimationClip.length);

            void AddEvent(string name, float time)
            {
                var animEvent = new AnimationEvent();
                animEvent.functionName = name;
                animEvent.time = time;
                AnimationUtility.SetAnimationEvents(AnimationClip, AnimationClip.events.Concat(new []{animEvent}).ToArray());
                EditorUtility.SetDirty(AnimationClip);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }

        private List<string> GetNames()
        {
            return AnimatorStatesNames.GetAnimatorNamesValues();
        }
#endif
    }
}
