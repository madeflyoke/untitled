using BehaviorDesigner.Runtime.Tasks;

namespace BT.Nodes.Interfaces
{
    public interface ICondition
    {
        public abstract TaskStatus GetConditionStatus();
    }
}
