using Builders.Interfaces;
using Components.Animation;
using UnityEngine;

namespace Builders
{
    public class AnimationComponentBuilder : IBuilder<AnimationComponent>
    {
        private readonly GameObject _componentsHolder;
        private Avatar _avatar;
        private RuntimeAnimatorController _animatorController;
        
        private bool _animationEventsListener;
        
        public AnimationComponentBuilder(GameObject componentsHolder)
        {
            _componentsHolder = componentsHolder;
        }
        
        public AnimationComponentBuilder SetAnimatorData(Avatar avatar, RuntimeAnimatorController animatorController)
        {
            _avatar = avatar;
            _animatorController = animatorController;
            return this;
        }

        public AnimationComponentBuilder AddAnimationEventsListener()
        {
            _animationEventsListener = true;
            return this;
        }
        
        public AnimationComponent Build()
        {
            var animator = _componentsHolder.AddComponent<Animator>();
            animator.avatar = _avatar;
            animator.runtimeAnimatorController = _animatorController;

            AnimationEventsListener animationEventsListener = null;
            if (_animationEventsListener)
            {
                animationEventsListener = _componentsHolder.AddComponent<AnimationEventsListener>();
            }
            
            return new AnimationComponent(animator, animationEventsListener);
        }
    }
}
