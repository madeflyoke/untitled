using Builders.Utility;
using Components;
using Components.Interfaces;
using Components.Settings;
using Components.View;
using Interfaces;
using UnityEngine;

namespace Factories.Decorators
{
    public class ModelHolderDecorator : IEntityDecorator
    {
        private readonly ModelHolderSettings _modelHolderSettings;
        private readonly EntityHolder _entityHolder;
        
        public ModelHolderDecorator(EntityHolder entityHolder, ModelHolderSettings modelHolderSettings)
        {
            _modelHolderSettings = modelHolderSettings;
            _entityHolder = entityHolder;
        }
        
        public IEntityComponent Decorate()
        {
            var modelHolder = CreateModelHolder(_entityHolder.ViewTransform);
            return modelHolder;
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
