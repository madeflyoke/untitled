using System;
using BehaviorDesigner.Runtime.Tasks;
using BT.Interfaces;
using Components.Combat.Projectiles;
using UnityEngine;

namespace Components.Combat.Actions
{
    [Serializable]
    public class ShootProjectile : IBehaviorAction
    {
        [SerializeField] private Projectile _projectilePrefab;

        public TaskStatus Execute()
        {
            return TaskStatus.Failure;
        }
    }
}
