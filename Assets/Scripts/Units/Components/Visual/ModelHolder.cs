using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Units.Components.Interfaces;
using UnityEngine;

namespace Units.Components.Visual
{
    public class ModelHolder : MonoBehaviour, IUnitComponent
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

