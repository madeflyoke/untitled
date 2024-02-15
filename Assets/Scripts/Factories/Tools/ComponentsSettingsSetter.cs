using System.Collections.Generic;
using Components.Settings.Interfaces;
using UnityEngine;

namespace Factories.Tools
{
    public class ComponentsSettingsSetter : MonoBehaviour
    {
        private void SetRequiredComponentSetting<TRequiredComponentType>(List<IComponentsSettingsHolder> settingsHolder) 
            where TRequiredComponentType: IComponentSettings
        {
            settingsHolder.ForEach(x=>x.ComponentsSettingsHolder.AddComponentSettings<TRequiredComponentType>());
        }
        
        private void SetRequiredComponentSetting<TRequiredComponentType>(IComponentsSettingsHolder settingsHolder) 
            where TRequiredComponentType: IComponentSettings
        {
            settingsHolder.ComponentsSettingsHolder.AddComponentSettings<TRequiredComponentType>();
        }
    }
}
