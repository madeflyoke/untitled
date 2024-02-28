using Builders;
using Components.Health;
using Components.Interfaces;
using Components.Settings;
using Interfaces;
using Units.Base;

namespace Factories.Decorators
{
    public class HealthComponentDecorator : IEntityDecorator
    {
        private readonly HealthComponentSettings _healthComponentSettings;
        
        public HealthComponentDecorator(HealthComponentSettings healthComponentSettings)
        {
            _healthComponentSettings = healthComponentSettings;
        }
        
        public IEntityComponent Decorate()
        {
            var healthController = CreateHealthController();
            return healthController;
        }

        private HealthComponent CreateHealthController()
        {
            HealthComponentBuilder builder = new();

            return builder
                .SetMaxHealth(_healthComponentSettings.BaseHealth)
                .Build();
        }
    }
}
