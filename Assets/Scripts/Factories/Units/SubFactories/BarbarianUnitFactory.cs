using Components;
using Components.Settings;
using Factories.Decorators;
using Factories.Units.SubFactories.Attributes;
using Factories.Units.SubFactories.Base;
using Units.Base;
using Units.Enums;

namespace Factories.Units.SubFactories
{
    [UnitVariant(UnitVariant = UnitVariant.BARBARIAN)]
    public class BarbarianUnitFactory : UnitSubFactory
    {
        public override UnitEntity CreateProduct()
        {
            DecorateBy(new ModelHolderDecorator(Config.ComponentsSettingsHolder
                .GetComponentSettings<ModelHolderSettings>()));
            
            DecorateBy(new HealthComponentDecorator(Config.ComponentsSettingsHolder
                .GetComponentSettings<HealthComponentSettings>()));
            
            DecorateBy(new MovementComponentDecorator(GetEntityComponent<EntityHolder>(), Config.ComponentsSettingsHolder
                .GetComponentSettings<MovementComponentSettings>()));
            
            return base.CreateProduct();
        }
    }
}
