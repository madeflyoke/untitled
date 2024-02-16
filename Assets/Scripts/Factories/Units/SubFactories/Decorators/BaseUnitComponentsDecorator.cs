using Builders.Utility;
using Components;
using Components.Settings;
using Components.View;
using Interfaces;
using Units.Base;
using UnityEngine;

namespace Factories.Units.SubFactories.Decorators
{
    public class BaseUnitComponentsDecorator : IEntityDecorator<UnitEntity>
    {
        private readonly ModelHolderSettings _modelHolderSettings;
        
        public BaseUnitComponentsDecorator(ModelHolderSettings modelHolderSettings)
        {
            _modelHolderSettings = modelHolderSettings;
        }
        
        public UnitEntity Decorate(UnitEntity entity)
        {
            return CreateBaseComponents(entity);
        }

        private UnitEntity CreateBaseComponents(UnitEntity entity)
        {
            ModelHolder modelHolder = CreateUnitModelHolder(entity.GetEntityComponent<EntityHolder>().ViewTransform);
            entity.AddEntityComponent(modelHolder);
            return entity;
        }
        
        private ModelHolder CreateUnitModelHolder(Transform parent)
        {
            GameObjectComponentBuilder<ModelHolder> goBuilder = new GameObjectComponentBuilder<ModelHolder>();

            var modelHolder = goBuilder
                .SetPrefab(_modelHolderSettings.ModelHolderPrefab)
                .SetParent(parent)
                .SetPosition(parent.position)
                .SetRotation(parent.rotation)
                .Build();

            return modelHolder;
        }
    }
}
