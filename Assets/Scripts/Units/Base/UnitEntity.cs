using System;
using System.Collections.Generic;
using Factories.Interfaces;
using Units.Components.Interfaces;
using UnityEngine;

namespace Units.Base
{
    public class UnitEntity : MonoBehaviour, IFactoryProduct
    {
        private readonly Dictionary<Type, IUnitComponent> _components = new();

        public UnitEntity Initialize()
        {
            return this;
        }
        
        public UnitEntity AddUnitComponent (IUnitComponent unitComponent)
        {
            var componentType = unitComponent.GetType();
            if (_components.ContainsKey(componentType)==false) //need it?
            {
                _components.Add(componentType, unitComponent);
            }

            return this;
        }
        
        
        public TComponent GetUnitComponent<TComponent>() where TComponent : IUnitComponent
        {
            if (_components.ContainsKey(typeof(TComponent)))
            {
                return (TComponent) _components[typeof(TComponent)];
            }
            
            throw new Exception($"No component with type: {typeof(TComponent)}!");
        }

    }
}
