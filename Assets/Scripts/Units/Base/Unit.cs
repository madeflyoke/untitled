using System;
using System.Collections.Generic;
using Interfaces;
using Units.Components;
using Units.Configs;
using Units.StateMachine;
using UnityEngine;

namespace Units.Base
{
    public abstract class Unit : MonoBehaviour,IDamageable
    {
        [field: SerializeField] public virtual UnitComponents Components { get; protected set; }
        protected Dictionary<Type, IState> BehaviourStates { get; }= new();
        
        private IState _currentState;

        public virtual Unit Initialize(UnitConfig unitConfig)
        {
            InitializeStates();
            
            SwitchState<UnitIdleState>();
            return this;
        }

        protected virtual void InitializeStates()
        {
            BehaviourStates.Add(typeof(UnitIdleState), new UnitIdleState().Initialize());
        }
        
        
        public void SwitchState<TState>() where TState : IState
        {
            var newState = BehaviourStates[typeof(TState)];

            if (newState==null || _currentState==BehaviourStates[typeof(TState)])
            {
                return;
            }
            
            _currentState?.Exit();
            
            _currentState = newState;
            
            _currentState.Enter();
            Debug.LogWarning($"{name} current state: {_currentState}");
        }
        
        public void MakeDamage()
        {
            
        }

    }
}
