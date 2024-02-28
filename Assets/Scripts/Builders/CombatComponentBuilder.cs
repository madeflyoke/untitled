using System.Collections.Generic;
using BT.Interfaces;
using Builders.Interfaces;
using Components.Combat;

namespace Builders
{
    public class CombatComponentBuilder : IBuilder<CombatComponent>
    {
        private List<IBehaviorAction> _attackActions;

        public CombatComponentBuilder AddAttackActions (List<IBehaviorAction> actions)
        {
            _attackActions = actions;
            return this;
        }
        
        public CombatComponent Build()
        {
            return new CombatComponent(_attackActions);
        }
    }
}
