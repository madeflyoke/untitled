using System.Collections.Generic;
using Components.Animation.Interfaces;
using Components.Interfaces;
using Sirenix.Utilities;
using UnityEngine;

namespace Components.Animation
{
   public class AnimationComponent : IEntityComponent
   {
      private readonly AnimationEventsListener _animationEventsListener;
      private readonly Animator _animator;

      public AnimationComponent(Animator animator, AnimationEventsListener eventsListener = null)
      {
         _animator = animator;
         _animationEventsListener = eventsListener;
      }

      private void PlayAnimation(string name, float transitionDuration = 0.25f)
      {
         _animator.CrossFadeInFixedTime(name, transitionDuration);
      }
      
      private void PlayCustomAnimation(IAnimationCaller caller, AnimationClipData clipData)
      {
         Debug.LogWarning("PLAYCUSTOM "+clipData);
         _animationEventsListener.SetCaller(caller);
         if (_animator.runtimeAnimatorController is AnimatorOverrideController overrider)
         {
            if (clipData.AnimationClip!=null)
            {
               overrider[clipData.TargetStateName] = clipData.AnimationClip;
            }
         }
         PlayAnimation(clipData.TargetStateName, clipData.TransitionDuration);
      }

      public void RegisterAnimationCaller(ref IAnimationCaller animationCaller)
      {
         if (animationCaller!=null)
         {
            animationCaller.CallOnAnimation += PlayCustomAnimation;
            _animationEventsListener.AnimationEventFired += animationCaller.OnAnimationCallback;
         }
      }

      public void RegisterAnimationCallerMany(IEnumerable<IAnimationCaller> animationCallers)
      {
         animationCallers.ForEach(x=>RegisterAnimationCaller(ref x));
      }
   }
}
