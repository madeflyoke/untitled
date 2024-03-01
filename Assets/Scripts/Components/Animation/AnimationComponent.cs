using Components.Interfaces;
using UnityEngine;

namespace Components.Animation
{
   public class AnimationComponent : IEntityComponent
   {
      public AnimationEventsListener AnimationEventsListener { get; }
      
      private readonly Animator _animator;

      public AnimationComponent(Animator animator, AnimationEventsListener eventsListener = null)
      {
         _animator = animator;
         AnimationEventsListener = eventsListener;
      }
      
      public void PlayAnimation(string name, float transitionDuration = 0.25f)
      {
         _animator.CrossFadeInFixedTime(name, transitionDuration);
      }
      
      public void PlayCustomAnimation(string name, AnimationClip customCombatAnimation, float transitionDuration = 0.25f)
      {
         if (_animator.runtimeAnimatorController is AnimatorOverrideController overrider)
         {
            overrider[name] = customCombatAnimation;
         }
         PlayAnimation(name, transitionDuration);
      }
   }
}
