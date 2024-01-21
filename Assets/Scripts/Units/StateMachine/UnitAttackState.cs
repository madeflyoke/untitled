using Units.Components;

namespace Units.StateMachine
{
    public class UnitAttackState : UnitBehaviourState
    {
        public override IState Initialize(UnitComponents components)
        {
            base.Initialize(components);
            return this;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}