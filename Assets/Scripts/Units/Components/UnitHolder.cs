using Units.Components.Interfaces;
using UnityEngine;

namespace Units.Components
{
    public class UnitHolder : MonoBehaviour, IUnitComponent
    {
        [field: SerializeField] public Transform ViewTransform { get; private set; }
        [field:SerializeField, HideInInspector] public Transform SelfTransform { get; private set; }

        
#if UNITY_EDITOR

        private void OnValidate()
        {
            SelfTransform = transform;
        }

#endif
    }
}