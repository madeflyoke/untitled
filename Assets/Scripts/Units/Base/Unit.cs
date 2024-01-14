using Interfaces;
using Units.Components;
using Units.Configs;
using UnityEngine;

namespace Units.Base
{
    public abstract class Unit : MonoBehaviour, IDamageable
    {
        public UnitComponents Components { get; protected set; }
        protected UnitStats _currentStats;

        public virtual Unit Initialize(UnitConfig unitConfig)
        {
            _currentStats = new UnitStats()
            {
                AttackDamage = unitConfig.BaseAttackDamage,
                MovementSpeed = unitConfig.BaseMovementSpeed
            };

            Components = new UnitComponents();
            return this;
        }
        
        public void MakeDamage()
        {
            
        }

        public struct UnitStats
        {
            public float AttackDamage;
            public float MovementSpeed;
        }
        
    }
}
