using BehaviorDesigner.Runtime;
using UnityEngine;

namespace BT.Shared.Containers
{
    public class MovementSharedContainer
    {
        public SharedVector3 CurrentDestinationPoint;
    }
    
    public class MovementSharedContainerVariable : SharedVariable<MovementSharedContainer>
    {
        public static implicit operator MovementSharedContainerVariable(MovementSharedContainer value) 
        { return new MovementSharedContainerVariable{ Value = value }; }
    }
}
