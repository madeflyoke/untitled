using System.Collections.Generic;
using BT.Interfaces;
using Components.Interfaces;

namespace Components.Combat
{
    public class AttackActionsHolder : IEntityComponent //todo make just Actions Holder if reused?
    {
        private List<IBehaviorAction> _attackActions;

        public AttackActionsHolder(List<IBehaviorAction> attackActions)
        {
            _attackActions = attackActions;
        }
    }
}
