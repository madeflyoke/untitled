using Units.Configs;

namespace Units.Base
{
    public class MeleeUnit : Unit
    {
        public override Unit Initialize(UnitConfig unitConfig)
        {
            base.Initialize(unitConfig);
            return this;
        }
    }
}