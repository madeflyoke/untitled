using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BT.Interfaces;

namespace BT.Shared.Containers
{
    public class SelfCombatDataSharedContainer
    {
        public List<IBehaviorAction> AttackActionsSequence;
    }

    public class SelfCombatDataSharedContainerVariable : SharedVariable<SelfCombatDataSharedContainer>
    {
        public static implicit operator SelfCombatDataSharedContainerVariable(SelfCombatDataSharedContainer value) 
        { return new SelfCombatDataSharedContainerVariable{ Value = value }; }
    }
}
