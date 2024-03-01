using System;
using BehaviorDesigner.Runtime.Tasks;
using BT.Interfaces;
using Components.Combat.Projectiles;
using UnityEngine;

namespace Components.Combat.Actions
{
    public class ShootProjectile : CombatAction
    {
        [SerializeField] private Projectile _projectilePrefab;

        public override TaskStatus GetCurrentStatus()
        {
            return TaskStatus.Running;
        }

        public override void Execute()
        {
            
        }
    }
}
