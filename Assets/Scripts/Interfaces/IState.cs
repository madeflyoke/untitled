public interface IState
{
    public abstract IState Initialize();
 
    public abstract void Enter();
    
    public abstract void Exit();
}
