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

        public CombatComponentDecorator(CombatComponentSettings combatComponentSettings)
        {
            _combatComponentSettings = combatComponentSettings;
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
                .Build();
        }
    }
}
