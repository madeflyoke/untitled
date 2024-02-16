namespace Interfaces
{
    public interface IEntityDecorator<TEntity> where TEntity : IEntity
    {
        public abstract TEntity Decorate(TEntity entity);
    }
}
