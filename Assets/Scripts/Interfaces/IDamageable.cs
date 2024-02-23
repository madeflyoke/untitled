namespace Interfaces
{
    public interface IDamageable
    {
        public abstract bool IsAlive { get; }
        public abstract void TakeDamage(int value);
    }
}
