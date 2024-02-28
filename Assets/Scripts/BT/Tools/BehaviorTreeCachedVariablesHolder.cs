using System;
using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace BT.Tools
{
    public class BehaviorTreeCachedVariablesHolder : SerializedMonoBehaviour
    {
        [SerializeField] private BehaviorTree _behaviorTree;
        [OdinSerialize, ReadOnly] private Dictionary<Type, SharedVariable> _sharedVariables;

        public TVariable GetVariable<TVariable>() where  TVariable : SharedVariable
        {
            return (TVariable) _sharedVariables[typeof(TVariable)];
        }


#if UNITY_EDITOR
        
        private void Setup()
        {
            _sharedVariables = _behaviorTree.GetAllVariables().ToDictionary(x => x.GetType());
        }
        
        private void OnValidate()
        {
            if (_behaviorTree==null)
            {
                _behaviorTree = GetComponent<BehaviorTree>();
            }
            Setup();
        }
        
#endif
       
    }
}
