using System;
using Components.Animation;
using Components.Animation.Interfaces;
using Components.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Components.Movement
{
    public class NavMeshMovementComponent : IEntityComponent, IAnimationCaller, IDisposable
    {
        private bool IsAgentMoving => _agent.velocity.magnitude > 0f;

        public Action<IAnimationCaller, AnimationClipData> CallOnAnimation { get; set; }
        private readonly NavMeshAgent _agent;
        
        private readonly IDisposable _agentSpeedObserver;

        public NavMeshMovementComponent(NavMeshAgent agent)
        {
            _agent = agent;
            _agentSpeedObserver = this.ObserveEveryValueChanged(x => x.IsAgentMoving).Skip(1)
                .Subscribe(x =>
            {
                if (x)
                {
                    OnAgentMoving();
                }
                else
                {
                    OnAgentStopped();
                }
            });
        }

        private void OnAgentMoving()
        {
            CallOnAnimation?.Invoke(this, new AnimationClipData(targetStateName: AnimatorStatesNames.Moving));
        }

        private void OnAgentStopped()
        {
            CallOnAnimation?.Invoke(this, new AnimationClipData(targetStateName: AnimatorStatesNames.Idle));
        }

        public void Dispose()
        {
            _agentSpeedObserver?.Dispose();
        }
    }
}
