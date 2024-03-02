using System.Collections.Generic;
using Components.Animation;
using Components.Combat.Actions;
using Components.Interfaces;

namespace Components.Combat
{
    public class CombatComponent : IEntityComponent
    {
        private readonly List<CombatAction> _combatActions;

        public CombatComponent(List<CombatAction> actions)
        {
            _combatActions = actions;
        }
        
        public List<CombatAction> GetCombatActions() => _combatActions;

    }
}
