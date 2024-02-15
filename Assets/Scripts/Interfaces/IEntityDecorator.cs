namespace Interfaces
{
    public interface IEntityDecorator<TEntity> where TEntity : IEntity
    {
        public abstract TEntity WrappedEntity { get; } 
        public abstract TEntity Decorate();
    }
}
