using Builders;
using Components.Animation;
using Components.Combat;
using Components.Interfaces;
using Components.Settings;
using Interfaces;

namespace Factories.Decorators
{
    public class CombatComponentDecorator : IEntityDecorator
    {
        private readonly CombatComponentSettings _combatComponentSettings;
        private readonly AnimationComponent _animationComponent;

        public CombatComponentDecorator(CombatComponentSettings combatComponentSettings, AnimationComponent animationComponent)
        {
            _combatComponentSettings = combatComponentSettings;
            _animationComponent = animationComponent;
        }
        
        public IEntityComponent Decorate()
        {
            return CreateCombatComponent();
        }

        private CombatComponent CreateCombatComponent()
        {
            var builder = new CombatComponentBuilder(_animationComponent);

            return builder
                .AddAttackActions(_combatComponentSettings.CombatActions)
                .Build();
        }
    }
}
