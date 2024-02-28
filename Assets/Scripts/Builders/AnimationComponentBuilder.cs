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

        public AnimationComponentBuilder(GameObject componentsHolder)
        {
            _componentsHolder = componentsHolder;
        }
        
        public AnimationComponentBuilder AddAnimatorData(Avatar avatar, RuntimeAnimatorController animatorController)
        {
            _avatar = avatar;
            _animatorController = animatorController;
            return this;
        }
        
        public AnimationComponent Build()
        {
            var animator = _componentsHolder.AddComponent<Animator>();
            animator.avatar = _avatar;
            animator.runtimeAnimatorController = _animatorController;
            
            return new AnimationComponent(animator);
        }
        
    }
}
