using BehaviorDesigner.Runtime;
using Interfaces;
using Units.Base;

namespace BT.Shared
{
    public class SharedUnitEntity : SharedVariable<UnitEntity>
    {
        public static implicit operator SharedUnitEntity(UnitEntity value) { return new SharedUnitEntity { Value = value }; }
    }
}
