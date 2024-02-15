using System;
using System.Collections.Generic;
using System.Linq;
using Components.Settings.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components.Settings
{
    public class ComponentsSettingsHolder : MonoBehaviour
    {
        [BoxGroup("CommonStats")]
        [ListDrawerSettings(HideAddButton = true, HideRemoveButton = true),
         SerializeField] [HideReferenceObjectPicker] private List<IComponentSettings> _componentsSettings;
        
        public void AddComponentSettings<TComponentType> () where TComponentType: IComponentSettings
        {
            _componentsSettings ??= new List<IComponentSettings>();
            if (IsComponentSettingsExists<TComponentType>(out IComponentSettings statsSettings)==false)
            {
                _componentsSettings.Add(Activator.CreateInstance<TComponentType>());
            }
        }
        
        private bool IsComponentSettingsExists<TComponentType>(out IComponentSettings statsSettings)where TComponentType : IComponentSettings
        {
            statsSettings = _componentsSettings.FirstOrDefault(x => x.GetType() == typeof(TComponentType));
            return statsSettings != null;
        }

        public TComponentType GetComponentSettings<TComponentType>() where TComponentType : IComponentSettings
        {
            if (IsComponentSettingsExists<TComponentType>(out IComponentSettings statsSettings))
            {
                return (TComponentType) statsSettings;
            }

            return default;
        }

    }
}
