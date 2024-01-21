using Units.Base;
using Units.Configs;
using Units.Enums;
using UnityEngine;

namespace Factories
{
    public class UnitsFactory : MonoBehaviour
    {
        [SerializeField] private UnitsConfigsContainer _unitsConfigsContainer;

        public Unit CreateUnit(UnitClass unitClass, UnitTeam team, Vector3 spawnPosition = default, Quaternion rotation = default,  Transform parent = null)
        {
            var config = _unitsConfigsContainer.GetConfig(unitClass);
            var unitPrefab = config.UnitPrefab;
            return Instantiate(unitPrefab, spawnPosition, rotation==default? Quaternion.identity:rotation, parent).Initialize(config, team);
        }
        
    }
}
