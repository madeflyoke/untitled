using Factories.Components;
using Factories.Interfaces;
using Factories.Units.SubFactories.Decorators;
using Units.Base;
using Units.Configs;
using Utility;

namespace Factories.Units.SubFactories
{
    public class BarbarianUnitFactory : IFactory<UnitEntity>
    {
        private readonly UnitEntity _unitEntity;
        
        public BarbarianUnitFactory(CustomTransformData spawnData, UnitConfig config)
        {
            UnitEntity entity = new EntityFactory<UnitEntity>(spawnData, config.UnitClass.ToString()).CreateProduct();
            UnitEntity baseEntityComponents = new BaseUnitComponentsDecorator(entity, config).Decorate();
            _unitEntity = baseEntityComponents;
        }

        public UnitEntity CreateProduct()
        {
            return _unitEntity;
        }
    }
}
