using Components.Interfaces;

namespace Interfaces
{
    public interface IEntity
    {
        public abstract IEntity AddEntityComponent(IEntityComponent unitEntityComponent);

        public abstract TComponent GetEntityComponent<TComponent>() where TComponent : IEntityComponent;
    }
}
