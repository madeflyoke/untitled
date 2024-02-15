using Components.Settings;
using Components.Settings.Interfaces;
using Sirenix.OdinInspector;
using Units.Enums;
using UnityEngine;

namespace Units.Configs
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "UnitConfig")]
    public class UnitConfig : SerializedScriptableObject, IComponentsSettingsHolder
    {
        [BoxGroup("General")]
        [field: SerializeField] public UnitClass UnitClass;
        
        [BoxGroup("ComponentsSettings")]
        [field: SerializeField] public ComponentsSettingsHolder ComponentsSettingsHolder { get; private set; }
        
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseAttackDamage = 5f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseMovementSpeed = 5f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float AttackRange = 5f;


    }
}
