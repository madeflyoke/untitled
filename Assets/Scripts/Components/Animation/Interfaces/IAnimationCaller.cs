using System;
using Components.Animation.Enums;

namespace Components.Animation.Interfaces
{
    public interface IAnimationCaller
    {
        public abstract Action<IAnimationCaller, AnimationClipData> CallOnAnimation { get; set; }
        public void OnAnimationCallback(IAnimationCaller caller, AnimationEventType eventType){}
    }

}