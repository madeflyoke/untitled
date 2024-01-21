using System;
using UniRx;
using Units.Components;
using UnityEngine;

namespace Units.StateMachine
{
    public class UnitIdleState : UnitBehaviourState
    {
        private IDisposable _test;
        
        public override IState Initialize(UnitComponents components)
        {
            base.Initialize(components);
            return this;
        }

        public override void Enter()
        {
            if (Components.Unit.Team == UnitTeam.ALLIES)
            {
                _test = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.K)).Subscribe(_ =>
                {
                    Components.Unit.SwitchState<UnitChasingState>();
                });
            }
        }

        public override void Exit()
        {
            _test?.Dispose();
        }
    }
}