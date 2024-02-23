using BehaviorDesigner.Runtime;
using Interfaces;

namespace BT.Shared.Containers
{
    public class DamageableTargetSharedContainer
    {
        public SharedDamageable TargetDamageable;
        public SharedTransform TargetTransform;
    }
    
    public class DamageableTargetSharedContainerVariable : SharedVariable<DamageableTargetSharedContainer>
    {
        public static implicit operator DamageableTargetSharedContainerVariable(DamageableTargetSharedContainer value) 
        { return new DamageableTargetSharedContainerVariable{ Value = value }; }
    }
}
