using BehaviorDesigner.Runtime;

namespace BT.Shared.Containers
{
    public class SelfGeneralDataSharedContainer
    {
        public SharedTransform SelfTransform;
    }
    
    public class SelfGeneralDataSharedContainerVariable : SharedVariable<SelfGeneralDataSharedContainer>
    {
        public static implicit operator SelfGeneralDataSharedContainerVariable(SelfGeneralDataSharedContainer value) { return new SelfGeneralDataSharedContainerVariable{ Value = value }; }
    }
}
