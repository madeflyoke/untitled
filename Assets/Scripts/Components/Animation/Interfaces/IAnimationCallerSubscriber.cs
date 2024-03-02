namespace Components.Animation.Interfaces
{
    public interface IAnimationCallerSubscriber
    {
        public abstract void RegisterAnimationCaller(ref IAnimationCaller animationCaller);
    }
}
