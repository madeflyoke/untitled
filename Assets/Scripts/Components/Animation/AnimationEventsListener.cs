using System;
using Components.Animation.Enums;
using Components.Animation.Interfaces;
using UnityEngine;

namespace Components.Animation
{
    [RequireComponent(typeof(Animator))]
    public class AnimationEventsListener : MonoBehaviour
    {
        public event Action<IAnimationCaller, AnimationEventType> AnimationEventFired;
        
        private IAnimationCaller _currentCaller;
        
        public void SetCaller(IAnimationCaller caller)
        {
            _currentCaller = caller;
        }
        
        public void OnAnimationStart()
        {
            Debug.LogWarning("ANIMATION START");
            AnimationEventFired?.Invoke(_currentCaller, AnimationEventType.START);
        }

        public void OnAnimationEnd()
        {
            Debug.LogWarning("ANIMATION END");
            AnimationEventFired?.Invoke(_currentCaller, AnimationEventType.END);
        }
    }
}