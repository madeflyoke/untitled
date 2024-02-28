using System.Collections.Generic;
using Components.Interfaces;

namespace Interfaces
{
    public interface IEntityDecorator
    {
        public abstract IEntityComponent Decorate();
    }
}
