using System.Collections.Generic;
using Sirenix.OdinInspector;
using Units.Components.Interfaces;
using Units.Components.Visual;
using Units.Enums;
using UnityEngine;

namespace Units.Configs
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "UnitConfig")]
    public class UnitConfig : SerializedScriptableObject
    {
        [BoxGroup("General")]
        [field: SerializeField] public UnitClass UnitClass;

        [BoxGroup("View")] 
        [field: SerializeField] public ModelHolder ModelHolderPrefab;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseHealth = 100f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseAttackDamage = 5f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseMovementSpeed = 5f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float AttackRange = 5f;


    }
}
