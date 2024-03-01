using System;
using System.Collections.Generic;
using BT.Interfaces;
using Components.Combat.Actions;
using Components.Settings.Interfaces;
using Sirenix.Serialization;

namespace Components.Settings
{
    [Serializable]
    public class CombatComponentSettings : IComponentSettings
    {
        [OdinSerialize] public List<CombatAction> CombatActions;
    }
}
