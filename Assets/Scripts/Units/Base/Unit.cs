using System;
using System.Collections.Generic;
using Interfaces;
using Sirenix.OdinInspector;
using Units.Components;
using Units.Configs;
using Units.StateMachine;
using UnityEditor;
using UnityEngine;

namespace Units.Base
{
    public abstract class Unit : MonoBehaviour,IDamageable
    {
        public UnitTeam Team { get; private set; }
        public Unit CurrentEnemyTarget { get; private set; }
        public abstract UnitConfig Config { get; }

        [field: SerializeField] public virtual UnitComponents Components { get; protected set; }
        protected Dictionary<Type, IState> BehaviourStates { get; }= new();
        
        private IState _currentState;

        public virtual Unit Initialize(UnitConfig unitConfig, UnitTeam team)
        {
            Team = team;
            InitializeStates();
            
            SwitchState<UnitIdleState>();
            return this;
        }

        protected virtual void InitializeStates()
        {
            BehaviourStates.Add(typeof(UnitIdleState), new UnitIdleState().Initialize(Components));
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

        public void SetEnemyTarget(Unit enemyTarget)
        {
            CurrentEnemyTarget = enemyTarget;
        }
        
        public void MakeDamage()
        {
            
        }

#if UNITY_EDITOR

        [SerializeField, ReadOnly] private UnitConfig editorConfig;
        
        private void OnValidate()
        {
            
            if (Components!=null)
            {
                Components.Unit = this;
            }

            if (editorConfig==null)
            {
               var asset = AssetDatabase.FindAssets("UnitsConfigsContainer");
               foreach (var item in asset)
               {
                  var so = AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(item));
                  if (so!=null)
                  {
                      var container = (UnitsConfigsContainer)so;
                      if (container!=null)
                      {
                          editorConfig = container.GetConfig(this);
                      }
                  }
               }
            }
        }

        private void OnDrawGizmos()
        {
            if (Team==UnitTeam.ALLIES)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(transform.position+Vector3.up*2f, 1f);
            }
            else if (Team==UnitTeam.ENEMIES)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position+Vector3.up*2f, 1f);
            }

            if (editorConfig)
            {
                Handles.color = Color.yellow;
                Handles.DrawWireDisc(transform.position, Vector3.up, editorConfig.AttackRange);
            }
        }
#endif
        
    }
}
