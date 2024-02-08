using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace Units.StateMachine
{
    public class UnitChasingState : UnitBehaviourState
    {
        private IDisposable _movingDisposable;
        private NavMeshAgent _agent;
        private Transform _targetTr;
        
        public override IState Initialize()
        {
            base.Initialize();
            // _agent = components.NavMeshAgent;

            return this;
        }

        public override void Enter()
        {
            // SetTarget();
            // _movingDisposable = Observable.EveryFixedUpdate()
            //     .Subscribe(x => ChaseTowardsTarget());
        }

        private void SetTarget()
        {
            // Components.Unit.SetEnemyTarget(EnemiesSpawner.Instance.EnemiesSpawnedUnits
            //     .OrderBy(x => Vector3.Distance(Components.Unit.transform.position, x.transform.position)).FirstOrDefault());
            // _targetTr = Components.Unit.CurrentEnemyTarget.transform;
        }

        private void ChaseTowardsTarget()
        {
            // var distance = Vector3.Distance(Components.Unit.transform.position,
            //     _targetTr.position);
            //
            // Debug.LogWarning("Distance: "+distance);
            //
            // if (distance<= Components.Unit.Config.AttackRange)
            // {
            //     _agent.isStopped = true;
            //     Components.Unit.SwitchState<UnitAttackState>();
            //     return;
            // }
            //
            // SetClosestDestinationPoint();
        }
        
        private void SetClosestDestinationPoint()
        {
            NavMesh.SamplePosition(_targetTr.transform.position, out NavMeshHit hit, 2f, 1);
            
            _agent.destination = hit.position;
            
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //
            // if (Physics.Raycast(ray, out RaycastHit castHit, 100f))
            // {
            //     NavMesh.SamplePosition(castHit.point, out NavMeshHit hit, 2f, 1);
            //
            //     _agent.destination = hit.position;
            // }
        }

        public override void Exit()
        {
            _movingDisposable?.Dispose();
        }
    }
}