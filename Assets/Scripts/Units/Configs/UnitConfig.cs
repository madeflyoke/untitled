using Sirenix.OdinInspector;
using Units.Base;
using Units.Components;
using Units.Enums;
using UnityEngine;

namespace Units.Configs
{
    public abstract class UnitConfig : ScriptableObject
    {
        [BoxGroup("General")]
        [field: SerializeField] public UnitClass UnitClass;
        [BoxGroup("General")]
        [field: SerializeField] public Unit UnitPrefab;
        [BoxGroup("CommonStats")]
        [field: SerializeField] public float BaseHealth = 100f;
        [BoxGroup("CommonStats")]
        [field: SerializeField] public float BaseAttackDamage = 5f;
        [BoxGroup("CommonStats")]
        [field: SerializeField] public float BaseMovementSpeed = 5f;
        
    }
}
