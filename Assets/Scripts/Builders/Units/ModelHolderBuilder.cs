using Builders.Units.Interfaces;
using Units.Components.Visual;
using UnityEngine;

namespace Builders.Units
{
    public class ModelHolderBuilder : IUnitComponentBuilder<ModelHolder>
    {
        private Transform _modelHolderParent;
        private GameObject _modelHolder;

        public ModelHolderBuilder(GameObject modelHolderPrefab)
        {
            _modelHolder = modelHolderPrefab;
        }
        
        public ModelHolderBuilder SetModelHolderParent(Transform parent)
        {
            _modelHolderParent = parent;
            return this;
        }
        
        public ModelHolder Build()
        {
            var modelHolder = GameObject.Instantiate(_modelHolder);
            return _modelHolderParent.gameObject.AddComponent<ModelHolder>();
        }
    }
}
