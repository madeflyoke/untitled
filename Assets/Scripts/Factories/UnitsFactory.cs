using System;
using System.Collections.Generic;
using Builders.Units.Containers;
using Builders.Utility;
using Units.Base;
using Units.Components;
using Units.Components.Interfaces;
using Units.Components.Visual;
using Units.Configs;
using Units.Enums;
using UnityEngine;

namespace Factories
{
    public class UnitsFactory : MonoBehaviourFactory<UnitEntity>
    {
        [SerializeField] private UnitsConfigsContainer _unitsConfigsContainer;
        [SerializeField] private UnitsBuildersPrefabs _buildersPrefabs;
        
        private UnitClass _targetUnitClass = UnitClass.NONE;
        
        public UnitsFactory SetTargetUnitClass(UnitClass unitClass)
        {
            _targetUnitClass = unitClass;
            return this;
        }
        
        public override UnitEntity CreateProduct(Vector3 position = default, Quaternion rotation = default, Transform parent = null)
        {
            UnitHolder unitHolder = CreateUnitHolder(position, rotation, parent);
            
            UnitEntity unitEntity = CreateUnitEntity(unitHolder.SelfTransform);
            unitEntity.AddUnitComponent(unitHolder);
            
            ModelHolder modelHolder = CreateUnitModelHolder(unitHolder.ViewTransform);
            unitEntity.AddUnitComponent(modelHolder);
            
            return unitEntity;
        }
        
        private UnitHolder CreateUnitHolder(Vector3 position = default, Quaternion rotation = default, Transform parent = null)
        {
            GameObjectBuilder<UnitHolder> goBuilder = new GameObjectBuilder<UnitHolder>();
            
            var unitHolder = goBuilder
                .SetPrefab(_buildersPrefabs.EmptyUnitHolderPrefab)
                .SetName(_targetUnitClass.ToString())
                .SetParent(parent)
                .SetRotation(rotation)
                .SetPosition(position)
                .Build();
            
            return unitHolder;
        }

        private UnitEntity CreateUnitEntity(Transform holder)
        {
            return holder.gameObject.AddComponent<UnitEntity>();
        }

        private ModelHolder CreateUnitModelHolder(Transform parent)
        {
            var config = _unitsConfigsContainer.GetConfig(_targetUnitClass);
            
            GameObjectBuilder<ModelHolder> goBuilder = new GameObjectBuilder<ModelHolder>();

            var modelHolder = goBuilder
                .SetPrefab(config.ModelHolderPrefab)
                .SetParent(parent)
                .SetPosition(parent.position)
                .SetRotation(parent.rotation)
                .Build();

            return modelHolder;
        }
    }
}
