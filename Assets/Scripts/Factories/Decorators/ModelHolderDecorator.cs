using Builders.Utility;
using Components;
using Components.Settings;
using Components.View;
using Interfaces;
using Units.Base;
using UnityEngine;

namespace Factories.Decorators
{
    public class ModelHolderDecorator : IEntityDecorator
    {
        private readonly ModelHolderSettings _modelHolderSettings;
        
        public ModelHolderDecorator(ModelHolderSettings modelHolderSettings)
        {
            _modelHolderSettings = modelHolderSettings;
        }
        
        public IEntity Decorate(IEntity entity)
        {
            var modelHolder = CreateModelHolder(entity.GetEntityComponent<EntityHolder>().ViewTransform);
            entity.AddEntityComponent(modelHolder);
            return entity;
        }
        
        private ModelHolder CreateModelHolder(Transform parent)
        {
            GameObjectComponentBuilder<ModelHolder> goBuilder = new ();
            
            return goBuilder
                .SetPrefab(_modelHolderSettings.ModelHolderPrefab)
                .SetParent(parent)
                .SetPosition(parent.position)
                .SetRotation(parent.rotation)
                .Build();
        }
    }
}
