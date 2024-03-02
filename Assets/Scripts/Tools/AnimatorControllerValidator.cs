using System.Collections.Generic;
using System.Linq;
using Components.Settings;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Utility;

namespace Tools
{
    public class AnimatorControllerValidator : StateMachineBehaviour
    {
#if UNITY_EDITOR
        
        [SerializeField] private AnimatorController _animatorController;
        [SerializeField] private string _path;
        
        [Button, Tooltip("Caution! Removes all files except empty animations in folder")]
        public void RecreateAndFillEmptyAnimations()
        {
            if (ValidateStatesNames()==false)
            {
                return;
            }
            
            string[] guids = AssetDatabase.FindAssets("t:AnimationClip", new[] { _path });
            List<AnimationClip> assets = new();

            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                assets.Add(AssetDatabase.LoadAssetAtPath<AnimationClip>(assetPath));
            }
            
            for (int i = assets.Count-1; i >= 0; i--)
            {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(assets[i]));
            }
            AssetDatabase.Refresh();
            
            _animatorController.layers[0].stateMachine.states
                .ForEach(x =>
                {
                    var motion = _animatorController.GetStateEffectiveMotion(x.state);
                    if (motion != null && motion.name.Equals(x.state.name))
                        return;
                    
                    var clip = new AnimationClip();
                    clip.name = x.state.name;
                    AssetDatabase.CreateAsset(clip, $"{_path}\\"+clip.name+".anim");
                    AssetDatabase.Refresh();
                    _animatorController.SetStateEffectiveMotion(x.state, clip);
                });

        }

        private bool ValidateStatesNames()
        {
            var values = AnimatorStatesNames.GetAnimationNamesValues();
            var names = _animatorController.layers[0].stateMachine.states.Select(x => x.state.name).ToArray();
            bool isOk = true;
            
            for (int i = 0; i < names.Length; i++)
            {
                if (values.Contains(names[i])==false)
                {
                    Debug.LogError($"Incorrect animator controller {_animatorController.name} state name <color=red>{names[i]}</color>, " +
                                   $"use <color=yellow>AnimatorStatesNames</color> class to choose one!");
                    isOk = false;
                }
            }

            return isOk;
        }
        
        private void OnValidate()
        {
            ValidateStatesNames();
        }

#endif
    }
}
