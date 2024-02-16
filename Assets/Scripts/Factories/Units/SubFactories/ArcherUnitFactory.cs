using Components.Settings;
using Factories.Units.SubFactories.Attributes;
using Factories.Units.SubFactories.Base;
using Factories.Units.SubFactories.Decorators;
using Units.Base;
using Units.Enums;

namespace Factories.Units.SubFactories
{
    [UnitVariant(UnitVariant = UnitVariant.ARCHER)]
    public class ArcherUnitFactory : UnitSubFactory
    {
        public override UnitEntity CreateProduct()
        {
            DecorateBy(new BaseUnitComponentsDecorator(Config.ComponentsSettingsHolder.GetComponentSettings<ModelHolderSettings>()));
            return base.CreateProduct();
        }
    }
}