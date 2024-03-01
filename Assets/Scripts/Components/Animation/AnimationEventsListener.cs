using System;
using UnityEngine;

namespace Components.Animation
{
    [RequireComponent(typeof(Animator))]
    public class AnimationEventsListener : MonoBehaviour
    {
        public event Action OnCurrentAnimationStart;
        public event Action OnCurrentAnimationEnd;

        public void OnAnimationStart()
        {
            Debug.LogWarning("ANIMATION START");
            OnCurrentAnimationStart?.Invoke();
        }

        public void OnAnimationEnd()
        {
            Debug.LogWarning("ANIMATION END");
            OnCurrentAnimationEnd?.Invoke();
        }
    }
}