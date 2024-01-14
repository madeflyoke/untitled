using Units.Configs;

namespace Units.Base
{
    public class RangedUnit : Unit
    {
        public override Unit Initialize(UnitConfig unitConfig)
        {
            base.Initialize(unitConfig);
            return this;
        }
    }
}