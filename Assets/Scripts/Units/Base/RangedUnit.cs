using Units.Components;
using Units.Configs;

namespace Units.Base
{
    public class RangedUnit : Unit
    {
        public override UnitConfig Config => _config;

        private RangedUnitConfig _config;
            
        public override Unit Initialize(UnitConfig unitConfig, UnitTeam team)
        {
            _config = (RangedUnitConfig) unitConfig;
            
            base.Initialize(unitConfig, team);
            return this;
        }
        
        protected override void InitializeStates()
        {
            base.InitializeStates();
        }
    }
}