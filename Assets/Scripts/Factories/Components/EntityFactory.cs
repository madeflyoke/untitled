using Builders.Utility;
using Components;
using Factories.Interfaces;
using Interfaces;
using UnityEngine;
using Utility;

namespace Factories.Components
{
    public class EntityFactory<TEntity> : IFactory<TEntity>
    where TEntity: MonoBehaviour, IEntity, IFactoryProduct
    {
        private readonly CustomTransformData _spawnData;
        private readonly string _name;
        private static EntityHolder _entityHolderPrefab = Resources.Load<EntityHolder>("EmptyUnitHolder");

        public EntityFactory(CustomTransformData spawnData, string name)
        {
            _spawnData = spawnData;
            _name = name;
        }

        public TEntity CreateProduct()
        {
            var holder = CreateEntityHolder();
            var entity = CreateEntity(holder.transform);
            entity.AddEntityComponent(holder);
            return entity;
        }
        
        private EntityHolder CreateEntityHolder()
        {
            GameObjectComponentBuilder<EntityHolder> goBuilder = new GameObjectComponentBuilder<EntityHolder>();
            
            var entityHolder = goBuilder
                .SetPrefab(_entityHolderPrefab)
                .SetName(_name)
                .SetParent(_spawnData.Parent)
                .SetRotation(_spawnData.Rotation)
                .SetPosition(_spawnData.Position)
                .Build();
            
            return entityHolder;
        }

        private TEntity CreateEntity(Transform holder)
        {
            return holder.gameObject.AddComponent<TEntity>();
        }

    }
}
