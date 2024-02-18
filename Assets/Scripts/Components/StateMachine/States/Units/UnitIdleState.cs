using System;
using Components.StateMachine.States.Units.Base;
using UniRx;
using UnityEngine;

namespace Components.StateMachine.States.Units
{
    public class UnitIdleState : UnitBehaviourState
    {
        private IDisposable _test;

        public UnitIdleState(StateMachine stateMachine) : base(stateMachine)
        {
            
        }
        
        public override void Enter()
        {
            _test = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.K)).Subscribe(_ =>
            {
                StateMachine.SwitchState<UnitChasingState>();
            });
        }

        public override void Exit()
        {
            _test?.Dispose();
        }
    }
}