using Builders;
using Components;
using Components.Interfaces;
using Components.Movement;
using Components.Settings;
using Interfaces;

namespace Factories.Decorators
{
    public class NavMeshMovementComponentDecorator : IEntityDecorator
    {
        private readonly MovementComponentSettings _movementComponentSettings;
        private readonly EntityHolder _entityHolder;
        
        public NavMeshMovementComponentDecorator(EntityHolder entityHolder, MovementComponentSettings movementComponentSettings)
        {
            _entityHolder = entityHolder;
            _movementComponentSettings = movementComponentSettings;
        }
        
        public IEntityComponent Decorate()
        {
            var movementComponent = CreateMovementComponent();
            return movementComponent;
        }

        private NavMeshMovementComponent CreateMovementComponent()
        {
            NavMeshMovementComponentBuilder builder = new NavMeshMovementComponentBuilder(_entityHolder.SelfTransform.gameObject);

            return builder
                .ApplyNavMeshAgentPreset(_movementComponentSettings.NavMeshAgentTemplate)
                .Build();
        }
    }
}
