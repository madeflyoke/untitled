using BehaviorDesigner.Runtime.Tasks;

namespace BT.Nodes.Conditionals
{
    public class InPreparingProcess : Conditional
    {
        private bool _isReady;

        public void Initialize(ref System.Action onReadyAction)
        {
            onReadyAction += SetReady;
        }
        
        public override TaskStatus OnUpdate()
        {
            return _isReady ? TaskStatus.Failure : TaskStatus.Running;
        }
        
        public void SetReady()
        {
            _isReady = true;
        }
    }
}
