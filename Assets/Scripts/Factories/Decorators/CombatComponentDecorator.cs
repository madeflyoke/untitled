using Builders;
using Components.Animation.Interfaces;
using Components.Combat;
using Components.Interfaces;
using Components.Settings;
using Interfaces;

namespace Factories.Decorators
{
    
    public class CombatComponentDecorator : IEntityDecorator
    {
        private readonly CombatComponentSettings _combatComponentSettings;
        private readonly IAnimationCallerSubscriber _animationsCallersSubscriber;

        public CombatComponentDecorator(CombatComponentSettings combatComponentSettings, IAnimationCallerSubscriber animationsCallersSubscriber)
        {
            _combatComponentSettings = combatComponentSettings;
            _animationsCallersSubscriber = animationsCallersSubscriber;
        }
        
        public IEntityComponent Decorate()
        {
            return CreateCombatComponent();
        }

        private CombatComponent CreateCombatComponent()
        {
            var builder = new CombatComponentBuilder();

            return builder
                .AddAttackActions(_combatComponentSettings.CombatActions)
                .RegisterActionsAnimationCalls(_animationsCallersSubscriber)
                .Build();
        }
    }
}
