using System;
using Factories.Interfaces;
using UnityEngine;

namespace Factories
{
    public abstract class MonoBehaviourFactory <T> : MonoBehaviour where T: IFactoryProduct
    {
        public abstract T CreateProduct(Vector3 position = default, Quaternion rotation = default, Transform parent = null);
    }

}