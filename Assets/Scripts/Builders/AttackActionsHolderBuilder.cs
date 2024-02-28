using Builders.Interfaces;
using Components.Combat;
using Components.Settings;

namespace Builders
{
    public class AttackActionsHolderBuilder : IBuilder<AttackActionsHolder>
    {
        private readonly AttackActionsHolderSettings _attackActionsHolderSettings;
        
        public AttackActionsHolderBuilder(AttackActionsHolderSettings attackActionsHolderSettings)
        {
            _attackActionsHolderSettings = attackActionsHolderSettings;
        }
        
        public AttackActionsHolder Build()
        {
            return new AttackActionsHolder(_attackActionsHolderSettings.Actions);
        }
    }
}
