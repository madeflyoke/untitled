using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Units.Base;
using Units.Enums;
using UnityEngine;

namespace Units.Configs
{
    [CreateAssetMenu(fileName = "UnitsConfigsContainer", menuName = "UnitsConfigsContainer")]
    public class UnitsConfigsContainer : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<UnitClass, UnitConfig> _configs;
        public List<UnitConfig> Configs => _configs.Values.ToList();
        
        public UnitConfig GetConfig(UnitClass unitClass)
        {
            return _configs[unitClass];
        }
        
#if UNITY_EDITOR

        private void OnValidate()
        {
            _configs = _configs.Values.ToDictionary(x => x.UnitClass, x => x);
        }
        
#endif
    }
}
