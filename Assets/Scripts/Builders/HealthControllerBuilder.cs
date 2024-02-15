using Builders.Interfaces;
using Components.Health;
using Interfaces;

namespace Builders
{
    public class HealthControllerBuilder : IBuilder<HealthController>
    {
        private int _maxHealth;
    
        public HealthControllerBuilder SetMaxHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
            return this;
        }
    
        public HealthController Build()
        {
            return new HealthController (_maxHealth);
        }
    }
}
