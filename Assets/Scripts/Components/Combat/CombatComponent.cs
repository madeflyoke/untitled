using System.Collections.Generic;
using BT.Interfaces;
using Components.Interfaces;

namespace Components.Combat
{
    public class CombatComponent : IEntityComponent
    {
        private readonly List<IBehaviorAction> _attackActions;

        public CombatComponent(List<IBehaviorAction> actions)
        {
            _attackActions = actions;
        }
        
        public List<IBehaviorAction> GetAttackActions() => _attackActions;

    }
}
