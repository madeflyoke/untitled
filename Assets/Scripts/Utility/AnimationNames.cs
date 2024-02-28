using System;
using System.Collections.Generic;
using System.Reflection;

namespace Utility
{
    public static class AnimationNames
    {
        public static string None = "None";
        public static string Idle = "Idle";
        public static string Moving = "Moving";
        public static string Combat = "CombatAction";
        
#if UNITY_EDITOR
        
        public static List<string> GetAnimationNamesValues()
        {
            List<string> animationList = new List<string>();

            Type animationType = typeof(AnimationNames);
            FieldInfo[] fields = animationType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    string animationValue = (string)field.GetValue(null);
                    animationList.Add(animationValue);
                }
            }

            return animationList;
        }
        
#endif
    }
}
