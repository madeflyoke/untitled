using Builders.Interfaces;
using Components.Health;
using Interfaces;

namespace Builders
{
    public class HealthComponentBuilder : IBuilder<HealthComponent>
    {
        private int _maxHealth;
    
        public HealthComponentBuilder SetMaxHealth(int maxHealth)
        {
            _maxHealth = maxHealth;
            return this;
        }
    
        public HealthComponent Build()
        {
            return new HealthComponent (_maxHealth);
        }
    }
}
