using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Units.Base;
using Units.Enums;
using UnityEngine;

namespace Units.Configs
{
    [CreateAssetMenu(fileName = "UnitsConfigsContainer", menuName = "UnitsConfigsContainer")]
    public class UnitsConfigsContainer :  SerializedScriptableObject
    {
        [SerializeField] private Dictionary<UnitClass, UnitConfig> _configs;

        public UnitConfig GetConfig(UnitClass unitClass)
        {
            return _configs[unitClass];
        }
        
#if UNITY_EDITOR

        public UnitConfig GetConfig(Unit unit)
        {
            return _configs.FirstOrDefault(x => x.Value.UnitPrefab == unit).Value;
        }
        
        private void OnValidate()
        {
            _configs = _configs.Values.ToDictionary(x => x.UnitClass, x => x);
        }
        
#endif
    }
}
