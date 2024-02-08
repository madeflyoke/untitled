using Builders.Units.Interfaces;
using Units.Components.Interfaces;
using UnityEngine;

namespace Builders.Utility
{
    public class GameObjectBuilder <TComponent> where TComponent : MonoBehaviour,IUnitComponent
    {
        private TComponent _prefab;
        
        private string _name = typeof(TComponent).Name;
        private Vector3 _spawnPosition;
        private Quaternion _rotation;
        private Transform _parent;
        
        public GameObjectBuilder<TComponent> SetName(string name)
        {
            _name = name;
            return this;
        }

        public GameObjectBuilder<TComponent>  SetPosition(Vector3 spawnPosition)
        {
            _spawnPosition = spawnPosition;
            return this;
        }

        public GameObjectBuilder<TComponent>  SetRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public GameObjectBuilder<TComponent>  SetParent(Transform parent)
        {
            _parent = parent;
            return this;
        }

        public GameObjectBuilder<TComponent> SetPrefab (TComponent prefab)
        {
            _prefab = prefab;
            return this;
        }

        public TComponent Build()
        {
            var componentGo = Object.Instantiate(
                _prefab,
                _spawnPosition,
                _rotation,
                _parent);
            componentGo.name =  _name;

            return componentGo;
        }
    }
}
