using System;
using System.Collections.Generic;
using Builders.Containers;
using Builders.Utility;
using Factories.Interfaces;
using Factories.Units.SubFactories;
using Units.Base;
using Units.Configs;
using Units.Enums;
using UnityEngine;
using Utility;

namespace Factories.Units
{
    public class UnitsFactory : MonoBehaviour, IFactory<UnitEntity>
    {
        [SerializeField] private UnitsConfigsContainer _unitsConfigsContainer;
        
        private readonly UnitProductRequestData _unitProductRequestData = new ();
        private readonly Dictionary<UnitClass, UnitEntity> _cachedUnits = new();
        
        public UnitsFactory SetProductRequestData(UnitClass unitClass, Vector3 position = default, Quaternion rotation = default, Transform parent = null)
        {
            _unitProductRequestData.TargetUnitClass = unitClass;
        
            _unitProductRequestData.SpawnData.Position = position;
            _unitProductRequestData.SpawnData.Rotation = rotation;
            _unitProductRequestData.SpawnData.Parent = parent;
            return this;
        }

        public UnitEntity CreateProduct()
        {
            // if (_cachedUnits.ContainsKey(_unitProductRequestData.TargetUnitClass))
            // {
            //     return MakeCopy(_cachedUnits[_unitProductRequestData.TargetUnitClass], _unitProductRequestData.SpawnData);
            // }

            return CreateTargetUnit();
        }

        private UnitEntity CreateTargetUnit()
        {
            switch (_unitProductRequestData.TargetUnitClass)
            {
                case UnitClass.BARBARIAN:
                    return CreateBarbarian();
                case UnitClass.ARCHER:
                    return CreateArcher();
            }

            throw new Exception("Invalid unit class request");
        }

        private UnitEntity CreateBarbarian()
        {
            return new BarbarianUnitFactory(_unitProductRequestData.SpawnData, _unitsConfigsContainer.GetConfig(_unitProductRequestData.TargetUnitClass))
                .CreateProduct();
        }

        private UnitEntity CreateArcher()
        {
            return new ArcherUnitFactory(_unitProductRequestData.SpawnData, _unitsConfigsContainer.GetConfig(_unitProductRequestData.TargetUnitClass))
                .CreateProduct();
        }

        private UnitEntity MakeCopy(UnitEntity original, CustomTransformData spawnData) //TODO Check in the end
        {
            GameObjectComponentBuilder<UnitEntity> goBuilder = new GameObjectComponentBuilder<UnitEntity>();

            return goBuilder
                .SetPrefab(original)
                .SetPosition(spawnData.Position)
                .SetRotation(spawnData.Rotation)
                .SetParent(spawnData.Parent)
                .Build();
        }

        // private HealthController CreateHealthController()
        // {
        //     var config = _unitsConfigsContainer.GetConfig(_unitProductRequestData.TargetUnitClass);
        //
        //     HealthControllerBuilder builder = new();
        //     builder.SetMaxHealth()
        // }

        private class UnitProductRequestData
        {
            public UnitClass TargetUnitClass = UnitClass.NONE;
            public readonly CustomTransformData SpawnData = new();
        }
    }
}
