// 代码生成时间: 2025-10-04 22:41:45
using System.Collections.Generic;
using UnityEngine;

namespace YourNamespace
{
    public class AnimationEffectLibrary
    {
        // 存储所有注册的动画效果
        private Dictionary<string, AnimationClip> animationEffects = new Dictionary<string, AnimationClip>();

        /**
         * 注册一个新的动画效果
         * @param effectName 动画效果的名称
         * @param animationClip 动画效果的剪辑
         */
        public void RegisterAnimationEffect(string effectName, AnimationClip animationClip)
        {
            if (string.IsNullOrEmpty(effectName))
            {
                Debug.LogError("Effect name cannot be null or empty.");
                return;
            }

            if (animationClip == null)
            {
                Debug.LogError("Animation clip cannot be null.");
                return;
            }

            if (animationEffects.ContainsKey(effectName))
            {
                Debug.LogWarning("Animation effect with the same name already exists. It will be replaced.");
            }

            animationEffects[effectName] = animationClip;
            Debug.Log($"Animation effect '{effectName}' registered successfully.");
        }

        /**
         * 播放注册的动画效果
         * @param effectName 动画效果的名称
         * @param target 动画目标对象
         */
        public void PlayAnimationEffect(string effectName, GameObject target)
        {
            if (!animationEffects.ContainsKey(effectName))
            {
                Debug.LogError($"Animation effect '{effectName}' not found.");
                return;
            }

            var animationClip = animationEffects[effectName];
            if (target.GetComponent<Animation>() == null)
            {
                target.AddComponent<Animation>();
            }

            var animation = target.GetComponent<Animation>();
            animation.Play(animationClip.name);
            Debug.Log($"Animation effect '{effectName}' is playing on target '{target.name}'.");
        }

        /**
         * 停止动画效果的播放
         * @param effectName 动画效果的名称
         * @param target 动画目标对象
         */
        public void StopAnimationEffect(string effectName, GameObject target)
        {
            if (!animationEffects.ContainsKey(effectName))
            {
                Debug.LogError($"Animation effect '{effectName}' not found.");
                return;
            }

            var animation = target.GetComponent<Animation>();
            if (animation != null)
            {
                animation.Stop();
                Debug.Log($"Animation effect '{effectName}' stopped on target '{target.name}'.");
            }
            else
            {
                Debug.LogWarning($"No animation component found on target '{target.name}'.");
            }
        }

        // 其他动画效果管理功能可以在这里添加...
    }
}