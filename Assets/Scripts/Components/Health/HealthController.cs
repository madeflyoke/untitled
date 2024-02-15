using System;
using Components.Interfaces;
using Interfaces;

namespace Components.Health
{
    public class HealthController: IDamageable, IEntityComponent
    {
        public event Action HealthEmptyEvent; 
        private readonly Health _health;
        //health view

        public HealthController(int maxHealth)
        {
            _health = new Health(maxHealth);
        }
        
        public void TakeDamage(int value)
        {
            _health.SubtractHealth(value);
            if (_health.CurrentHealth == 0)
            {
                HealthEmptyEvent?.Invoke();
            }
        }
    }
}
