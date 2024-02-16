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
        [SerializeField] private Dictionary<UnitVariant, UnitConfig> _configs;
        
        public UnitConfig GetConfig(UnitVariant unitVariant)
        {
            return _configs[unitVariant];
        }
        
#if UNITY_EDITOR

        private void OnValidate()
        {
            _configs = _configs.Values.ToDictionary(x => x.unitVariant, x => x);
        }
        
#endif
    }
}
