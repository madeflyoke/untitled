using Builders;
using Components.Health;
using Components.Settings;
using Interfaces;
using Units.Base;

namespace Factories.Decorators
{
    public class HealthComponentDecorator : IEntityDecorator<UnitEntity>
    {
        private readonly HealthComponentSettings _healthComponentSettings;
        
        public HealthComponentDecorator(HealthComponentSettings healthComponentSettings)
        {
            _healthComponentSettings = healthComponentSettings;
        }
        
        public UnitEntity Decorate(UnitEntity entity)
        {
            var healthController = CreateHealthController();
            entity.AddEntityComponent(healthController);
            return entity;
        }
        
        private HealthController CreateHealthController()
        {
            HealthControllerBuilder builder = new();

            return builder
                .SetMaxHealth(_healthComponentSettings.BaseHealth)
                .Build();
        }
    }
}
