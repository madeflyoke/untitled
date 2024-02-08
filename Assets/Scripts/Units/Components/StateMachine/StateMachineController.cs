using Units.Components.Interfaces;
using Units.Enums;

namespace Units.Components.StateMachine
{
    public class StateMachineController : IUnitComponent
    {
        private IStateHolder _stateHolder;
        private IState _currentState;
        
        public StateMachineController(IStateHolder stateHolder)
        {
            _stateHolder = stateHolder;
        }
        
        public void SwitchState<TState>() where TState : IState
        {
            var newState = _stateHolder.BehaviourStates[typeof(TState)];

            if (newState==null || _currentState==newState)
            {
                return;
            }
            
            _currentState?.Exit();
            
            _currentState = newState;
            
            _currentState.Enter();
        }

        private IStateHolder CreateStates(UnitClass unitClass) //todo change
        {
            switch (unitClass)
            {
                case UnitClass.NONE:
                    break;
                case UnitClass.BARBARIAN:
                    return new MeleeStatesHolder();
                case UnitClass.ARCHER:
                    return new RangedStatesHolder();
            }

            return null;
        }
    }
}