using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using BT.Interfaces;
using BT.Nodes.Actions;
using BT.Nodes.Conditionals;
using BT.Shared.Containers;
using Components.Health;
using Cysharp.Threading.Tasks;
using Interfaces;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class UnitTest : MonoBehaviour
{
    [SerializeField] private List<UnitTest> _enemies;
    
    private IDamageable Damageable;
    public NavMeshAgent _agent;
    public BehaviorTree _behaviorTree;
    [OdinSerialize] public List<IBehaviorAction> _attackActions;

    private void Awake()
    {
        Damageable = new HealthComponent(1);
    }

    [Button]
    public void SetDead()
    {
        Damageable.TakeDamage(100);
    }
    
    [Button]
    public void BehaviorOn()
    {
        MovementSharedContainer movementContainer =
            _behaviorTree.GetCachedVariablesHolder().GetVariable<MovementSharedContainerVariable>().Value;
        DamageableTargetSharedContainer damageableTargetSharedContainer =
            _behaviorTree.GetCachedVariablesHolder().GetVariable<DamageableTargetSharedContainerVariable>().Value;
        SelfDataSharedContainer selfContainer =
            _behaviorTree.GetCachedVariablesHolder().GetVariable<SelfDataSharedContainerVariable>().Value;
        selfContainer.SelfTransform = transform;
        
        
        _behaviorTree.FindTask<ValidateDamageableTarget>()
            .SetSharedVariables
            (damageableTargetSharedContainer.TargetDamageable, damageableTargetSharedContainer.TargetTransform);
        
        _behaviorTree.FindTask<FindClosestDamageableTarget>().Initialize(_enemies.ToDictionary(x=>x.transform,z=>z.Damageable))
            .SetSharedVariables(selfContainer.SelfTransform,
                damageableTargetSharedContainer.TargetDamageable, damageableTargetSharedContainer.TargetTransform);
        
        _behaviorTree.FindTask<SetClosestNavMeshPoint>()
            .SetSharedVariables(damageableTargetSharedContainer.TargetTransform,
                movementContainer.CurrentDestinationPoint);

        _behaviorTree.FindTask<IsTargetWithinRange>()
            .SetSharedVariables(selfContainer.SelfTransform, damageableTargetSharedContainer.TargetTransform, 3f);
        
        _behaviorTree.FindTask<MoveToPoint>().Initialize(_agent).SetSharedVariables(movementContainer.CurrentDestinationPoint);
        
        _behaviorTree.EnableBehavior();
    }

    [Button]
    public void SetReady()
    {
        _behaviorTree.FindTask<InPreparingProcess>().SetReady();
    }
}
