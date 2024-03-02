using System.Collections.Generic;
using System.Linq;
using Builders.Interfaces;
using Components.Animation;
using Components.Animation.Interfaces;
using Components.Combat;
using Components.Combat.Actions;
using Sirenix.Utilities;

namespace Builders
{
    public class CombatComponentBuilder : IBuilder<CombatComponent>
    {
        private List<CombatAction> _combatActions;
        
        public CombatComponentBuilder AddAttackActions (List<CombatAction> actions)
        {
            _combatActions = actions;
            return this;
        }

        public CombatComponentBuilder RegisterActionsAnimationCalls(IAnimationCallerSubscriber subscriber)
        {
            _combatActions?.Cast<IAnimationCaller>().ForEach(x => subscriber.RegisterAnimationCaller(ref x));
            return this;
        }

        public CombatComponent Build()
        {
            return new CombatComponent(_combatActions);
        }
    }
}
