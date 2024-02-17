using System;
using System.Collections.Generic;
using System.IO;
using Components.Settings;
using Components.Settings.Interfaces;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Units.Enums;
using UnityEngine;

namespace Units.Configs
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "UnitConfig")]
    public class UnitConfig : SerializedScriptableObject
    {
        [BoxGroup("General")]
        [field: SerializeField] public UnitVariant unitVariant;
        
        [BoxGroup("ComponentsSettings")] 
        [OdinSerialize] public ComponentsSettingsHolder ComponentsSettingsHolder = new();

        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseAttackDamage = 5f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float BaseMovementSpeed = 5f;
        // [BoxGroup("CommonStats")]
        // [field: SerializeField] public float AttackRange = 5f;
    }
}
