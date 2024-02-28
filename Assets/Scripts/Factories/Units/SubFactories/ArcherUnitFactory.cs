using Components;
using Components.Settings;
using Factories.Decorators;
using Factories.Units.SubFactories.Attributes;
using Factories.Units.SubFactories.Base;
using Units.Base;
using Units.Enums;

namespace Factories.Units.SubFactories
{
    [UnitVariant(UnitVariant = UnitVariant.ARCHER)]
    public class ArcherUnitFactory : UnitSubFactory
    {
        public override UnitEntity CreateProduct()
        {
            var entityHolder = GetEntityComponent<EntityHolder>();
            
            DecorateBy(new ModelHolderDecorator(entityHolder, Config.ComponentsSettingsHolder
                .GetComponentSettings<ModelHolderSettings>()));
            
            DecorateBy(new HealthComponentDecorator(Config.ComponentsSettingsHolder
                .GetComponentSettings<HealthComponentSettings>()));
            
            DecorateBy(new NavMeshMovementComponentDecorator(entityHolder, Config.ComponentsSettingsHolder
                .GetComponentSettings<MovementComponentSettings>()));

            DecorateBy(new AnimationComponentDecorator(entityHolder, Config.ComponentsSettingsHolder
                .GetComponentSettings<AnimationComponentSettings>()));
            
            return base.CreateProduct();
        }
    }
}