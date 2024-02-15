using Builders.Interfaces;
using UnityEngine;
using Utility;

namespace Builders.Utility
{
    public class GameObjectComponentBuilder <TComponent> : IBuilder<TComponent> where TComponent: MonoBehaviour
    {
        private TComponent _prefab;
        
        private string _name = typeof(TComponent).Name;
        private readonly CustomTransformData _spawnData = new();
        
        public GameObjectComponentBuilder<TComponent> SetName(string name)
        {
            _name = name;
            return this;
        }

        public GameObjectComponentBuilder<TComponent>  SetPosition(Vector3 spawnPosition)
        {
            _spawnData.Position = spawnPosition;
            return this;
        }

        public GameObjectComponentBuilder<TComponent>  SetRotation(Quaternion rotation)
        {
            _spawnData.Rotation = rotation;
            return this;
        }

        public GameObjectComponentBuilder<TComponent>  SetParent(Transform parent)
        {
            _spawnData.Parent = parent;
            return this;
        }

        public GameObjectComponentBuilder<TComponent> SetPrefab (TComponent prefab)
        {
            _prefab = prefab;
            return this;
        }

        public TComponent Build()
        {
            var componentGo = Object.Instantiate(
                _prefab,
                _spawnData.Position,
                _spawnData.Rotation,
                _spawnData.Parent);
            componentGo.name =  _name;

            return componentGo;
        }
    }
}
