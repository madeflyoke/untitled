using Sirenix.OdinInspector;
using UnityEngine;

namespace Units.Configs
{
    [CreateAssetMenu(menuName = "UnitsConfigs/RangedUnitConfig",fileName = "RangedUnitConfig")]
    public class RangedUnitConfig : UnitConfig
    {
        [BoxGroup("SpecialStats")]
        [field: SerializeField] public float AttackRange = 5f;
        [BoxGroup("SpecialStats")] 
        [field: SerializeField] public int ProjectilesPerShot = 1;
    }
}
