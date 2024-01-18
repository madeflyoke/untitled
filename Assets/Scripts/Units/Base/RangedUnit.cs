using Units.Components;
using Units.Configs;

namespace Units.Base
{
    public class RangedUnit : Unit
    {
        private RangedUnitConfig _config;
            
        public override Unit Initialize (UnitConfig unitConfig)
        {
            _config = (RangedUnitConfig) unitConfig;
            
            base.Initialize(unitConfig);
            return this;
        }
        
        protected override void InitializeStates()
        {
            base.InitializeStates();
        }
    }
}