using System;
using Units.Components.Interfaces;

namespace Builders.Units.Interfaces
{
    public interface IUnitComponentBuilder <TComponent> where TComponent: IUnitComponent
    {
        public abstract TComponent Build();
    }
}
