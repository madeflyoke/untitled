using System;
using BT.Tools;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
    // Wrapper for the Behavior class
    [AddComponentMenu("Behavior Designer/Behavior Tree")]
    [RequireComponent(typeof(BehaviourTreeCachedVariablesHolder))]
    public class BehaviorTree : Behavior
    {
        // intentionally left blank
        [SerializeField] private BehaviourTreeCachedVariablesHolder cachedVariablesHolder;

        public BehaviourTreeCachedVariablesHolder GetCachedVariablesHolder()
        {
            return cachedVariablesHolder ??= GetComponent<BehaviourTreeCachedVariablesHolder>();
        }

#if UNITY_EDITOR
        
        private void OnValidate()
        {
            cachedVariablesHolder ??= GetComponent<BehaviourTreeCachedVariablesHolder>();
        }
        
#endif
        
    }
}