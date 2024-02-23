using BehaviorDesigner.Runtime;

namespace BT.Shared.Containers
{
    public class SelfDataSharedContainer
    {
        public SharedTransform SelfTransform;
    }
    
    public class SelfDataSharedContainerVariable : SharedVariable<SelfDataSharedContainer>
    {
        public static implicit operator SelfDataSharedContainerVariable(SelfDataSharedContainer value) { return new SelfDataSharedContainerVariable{ Value = value }; }
    }
}
