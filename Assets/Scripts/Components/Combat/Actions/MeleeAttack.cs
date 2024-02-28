using BehaviorDesigner.Runtime.Tasks;
using BT.Interfaces;

namespace Components.Combat.Actions
{
    public class MeleeAttack : IBehaviorAction
    {
        
        
        public void Initialize()
        {
            
        }
        
        public TaskStatus Execute()
        {
            return TaskStatus.Failure;
        }
    }
}
