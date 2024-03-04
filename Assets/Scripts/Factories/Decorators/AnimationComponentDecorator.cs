using Builders;
using Components;
using Components.Interfaces;
using Components.Settings;
using Interfaces;

namespace Factories.Decorators
{
    public class AnimationComponentDecorator : IEntityDecorator
    {
        private readonly AnimationComponentSettings _animationComponentSettings;
        private readonly EntityHolder _entityHolder;
        
        public AnimationComponentDecorator(EntityHolder entityHolder, AnimationComponentSettings animationComponentSettings)
        {
            _animationComponentSettings = animationComponentSettings;
            _entityHolder = entityHolder;
        }

        public IEntityComponent Decorate()
        {
            var builder = new AnimationComponentBuilder(_entityHolder.SelfTransform.gameObject);
            
            return builder
                .SetAnimatorData(_animationComponentSettings.Avatar, _animationComponentSettings.OverrideAnimatorController)
                .AddAnimationEventsListener()
                .Build();;
        }
    }
}
