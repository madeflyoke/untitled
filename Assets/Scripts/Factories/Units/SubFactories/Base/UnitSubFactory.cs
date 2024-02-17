using System;
using Components.Settings;
using Components.Settings.Interfaces;
using Factories.Components;
using Factories.Interfaces;
using Interfaces;
using Units.Base;
using Units.Configs;
using Units.Enums;
using Unity.Collections;
using UnityEngine;
using Utility;

namespace Factories.Units.SubFactories.Base
{
    public abstract class UnitSubFactory : MonoBehaviour, IFactory<UnitEntity>
    {
        [field: SerializeField, ReadOnly] protected UnitConfig Config { get; private set; }
        private UnitEntity _unitEntity;

        public UnitSubFactory Initialize(CustomTransformData spawnData)
        {
            _unitEntity = new EntityFactory<UnitEntity>(spawnData, Config.unitVariant.ToString()).CreateProduct();
            
#if UNITY_EDITOR
            Debug.LogWarning($"Unit {Config.unitVariant} initialized with base entity.");
#endif
            return this;
        }

        public virtual UnitEntity CreateProduct()
        {
            return _unitEntity;
        }

        protected UnitEntity DecorateBy(IEntityDecorator<UnitEntity> decorator)
        {
            var entity = decorator.Decorate(_unitEntity);
            
#if UNITY_EDITOR
            Debug.LogWarning($"Unit {Config.unitVariant} decorated with {decorator.GetType().Name}.");
#endif
            return entity;
        }

#if UNITY_EDITOR
        
        public UnitSubFactory SetRelatedConfig(UnitConfig config)
        {
            Config = config;
            return this;
        }
#endif
    }
}
