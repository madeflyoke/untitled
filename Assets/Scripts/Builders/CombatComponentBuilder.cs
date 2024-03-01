using System.Collections.Generic;
using Builders.Interfaces;
using Components.Animation;
using Components.Combat;
using Components.Combat.Actions;

namespace Builders
{
    public class CombatComponentBuilder : IBuilder<CombatComponent>
    {
        private List<CombatAction> _combatActions;
        private readonly AnimationComponent _animationComponent;
            
        public CombatComponentBuilder(AnimationComponent animationComponent)
        {
            _animationComponent = animationComponent;
        }

        public CombatComponentBuilder AddAttackActions (List<CombatAction> actions)
        {
            _combatActions = actions;
            return this;
        }
        
        public CombatComponent Build()
        {
            return new CombatComponent(_combatActions,_animationComponent);
        }
    }
}
