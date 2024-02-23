using Builders;
using Components;
using Components.Movement;
using Components.Settings;
using Interfaces;
using UnityEngine;

namespace Factories.Decorators
{
    public class MovementComponentDecorator : IEntityDecorator
    {
        private MovementComponentSettings _movementComponentSettings;
        private EntityHolder _entityHolder;
        
        public MovementComponentDecorator(EntityHolder entityHolder,MovementComponentSettings movementComponentSettings)
        {
            _entityHolder = entityHolder;
            _movementComponentSettings = movementComponentSettings;
        }
        
        public IEntity Decorate(IEntity entity)
        {
            var movementComponent = CreateMovementComponent();
            
            entity.AddEntityComponent(movementComponent);
            return entity;
        }

        private MovementComponent CreateMovementComponent()
        {
            MovementComponentBuilder builder = new MovementComponentBuilder();

            return builder
                .ApplyNavMeshAgentPreset(_entityHolder.SelfTransform.gameObject,
                    _movementComponentSettings.NavMeshAgentTemplate)
                .Build();
        }
    }
}
