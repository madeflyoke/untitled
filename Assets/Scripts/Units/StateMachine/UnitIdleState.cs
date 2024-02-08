using System;
using UniRx;
using UnityEngine;

namespace Units.StateMachine
{
    public class UnitIdleState : UnitBehaviourState
    {
        private IDisposable _test;
        
        public override IState Initialize()
        {
            base.Initialize();
            return this;
        }

        public override void Enter()
        {
            // if (Components.Unit.Team == UnitTeam.ALLIES)
            // {
            //     _test = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.K)).Subscribe(_ =>
            //     {
            //         Components.Unit.SwitchState<UnitChasingState>();
            //     });
            // }
        }

        public override void Exit()
        {
            _test?.Dispose();
        }
    }
}