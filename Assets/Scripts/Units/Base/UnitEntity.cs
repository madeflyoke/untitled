using System;
using System.Collections.Generic;
using Components.Health;
using Components.Interfaces;
using Factories.Interfaces;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Units.Base
{
    public class UnitEntity : MonoBehaviour, IEntity, IFactoryProduct
    {
        [ShowInInspector, ReadOnly] private readonly Dictionary<Type, IEntityComponent> _components = new();
        
        public IEntity AddEntityComponent (IEntityComponent unitEntityComponent)
        {
            var componentType = unitEntityComponent.GetType();
            if (_components.ContainsKey(componentType)==false) //need it?
            {
                _components.Add(componentType, unitEntityComponent);
            }

            return this;
        }
        
        public TComponent GetEntityComponent<TComponent>() where TComponent : IEntityComponent
        {
            if (_components.ContainsKey(typeof(TComponent)))
            {
                return (TComponent) _components[typeof(TComponent)];
            }
            
            throw new Exception($"No component with type: {typeof(TComponent)}!");
        }
    }
}
