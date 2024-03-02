using System;
using BehaviorDesigner.Runtime.Tasks;
using BT.Tools;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
    // Wrapper for the Behavior class
    [AddComponentMenu("Behavior Designer/Behavior Tree")]
    [RequireComponent(typeof(BehaviorTreeCachedVariablesHolder))]
    public class BehaviorTree : Behavior
    {
        // intentionally left blank
        [SerializeField] private BehaviorTreeCachedVariablesHolder cachedVariablesHolder;

        public BehaviorTreeCachedVariablesHolder GetCachedVariablesHolder()
        {
            return cachedVariablesHolder ??= GetComponent<BehaviorTreeCachedVariablesHolder>();
        }

#if UNITY_EDITOR
        
        private void OnValidate()
        {
            cachedVariablesHolder ??= GetComponent<BehaviorTreeCachedVariablesHolder>();
        }
        
#endif

        public TTask FindTask<TTask>(string taskName) where TTask: Task
        {
            return FindTaskWithName(taskName) as TTask;
        }
        
    }
}