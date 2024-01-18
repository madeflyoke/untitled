using System;
using System.Linq;
using Units.Configs;
using Units.StateMachine;
using UnityEngine;

namespace Units.Base
{
    public class MeleeUnit : Unit
    {
        private MeleeUnitConfig _config;
            
        public override Unit Initialize(UnitConfig unitConfig)
        {
            _config = (MeleeUnitConfig) unitConfig;
            
            base.Initialize(unitConfig);
            return this;
        }
        
        protected override void InitializeStates()
        {
            base.InitializeStates();
            BehaviourStates.Add(typeof(UnitChasingState), new UnitChasingState().Initialize());
            BehaviourStates.Add(typeof(UnitAttackState), new UnitAttackState().Initialize());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SwitchState<UnitChasingState>();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                SwitchState<UnitAttackState>();
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                SwitchState<UnitIdleState>();
            }
        }

        public struct MeleeUnitStats
        {
            
        }
    }
}