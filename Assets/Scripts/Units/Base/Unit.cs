using Units.Configs;
using UnityEngine;

namespace Units.Base
{
    public abstract class Unit : MonoBehaviour
    {
        public abstract Unit Initialize(UnitConfig unitConfig);
    }
}
