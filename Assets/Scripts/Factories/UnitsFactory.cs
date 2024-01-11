using Units.Base;
using Units.Configs;
using Units.Enums;
using UnityEngine;

namespace Factories
{
    public class UnitsFactory : MonoBehaviour
    {
        [SerializeField] private UnitsConfigsContainer _unitsConfigsContainer;

        public Unit CreateUnit(UnitClass unitClass)
        {
            var config = _unitsConfigsContainer.GetConfig(unitClass);
            var unitPrefab = config.UnitPrefab;
            return Instantiate(unitPrefab, Vector3.zero, Quaternion.identity).Initialize(config);
        }
    }
}
