using Builders.Utility;
using Components;
using Components.Settings;
using Components.View;
using Interfaces;
using Units.Base;
using Units.Configs;
using UnityEngine;

namespace Factories.Units.SubFactories.Decorators
{
    public class BaseUnitComponentsDecorator : IEntityDecorator<UnitEntity>
    {
        public UnitEntity WrappedEntity { get; private set; }
        private readonly UnitConfig _config;
        
        public BaseUnitComponentsDecorator(UnitEntity unitEntity, UnitConfig config)
        {
            WrappedEntity = unitEntity;
            _config = config;
        }

        public UnitEntity Decorate()
        {
            return CreateBaseComponents();
        }

        private UnitEntity CreateBaseComponents()
        {
            ModelHolder modelHolder = CreateUnitModelHolder(WrappedEntity.GetEntityComponent<EntityHolder>().ViewTransform);
            WrappedEntity.AddEntityComponent(modelHolder);
            return WrappedEntity;
        }
        
        private ModelHolder CreateUnitModelHolder(Transform parent)
        {
            GameObjectComponentBuilder<ModelHolder> goBuilder = new GameObjectComponentBuilder<ModelHolder>();

            var modelHolder = goBuilder
                .SetPrefab(_config.ComponentsSettingsHolder.GetComponentSettings<ModelHolderSettings>().ModelHolderPrefab)
                .SetParent(parent)
                .SetPosition(parent.position)
                .SetRotation(parent.rotation)
                .Build();

            return modelHolder;
        }
        
    }
}
