using System.Collections.Generic;
using System.Linq;
using Components.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components.View
{
    public class ModelHolder : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private List<Material> _relatedMaterials;

#if UNITY_EDITOR

        private void OnValidate()
        {
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _relatedMaterials = _meshRenderer.sharedMaterials.ToList();
        }

        [Button]
        private void SetHalfMeshYPos()
        {
            _meshRenderer.transform.position += Vector3.up * (transform.position.y+0.01f - _meshRenderer.bounds.min.y);
        }

#endif
    }
}

