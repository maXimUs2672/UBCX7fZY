// 代码生成时间: 2025-10-07 18:13:46
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System.Collections.Generic;
using System.Threading.Tasks;
# 扩展功能模块

/// <summary>
/// A utility class for text-to-speech functionality in Unity.
/// </summary>
public class TextToSpeechTool : MonoBehaviour
# 优化算法效率
{
    /// <summary>
    /// The UI Text component to display messages.
    /// </summary>
    public Text messageText;

    /// <summary>
    /// The text input field where users can enter text to be spoken.
# TODO: 优化性能
    /// </summary>
    public InputField textInput;

    private readonly string textToSpeechService = "textToSpeech";
# 改进用户体验
    private readonly int textToSpeechRequestCode = 100;

    /// <summary>
# NOTE: 重要实现细节
    /// Unity Start method.
    /// </summary>
    private void Start()
    {
        #if UNITY_ANDROID
# 添加错误处理
        // Check if the text-to-speech permission is granted.
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        #endif
# 扩展功能模块
    }

    /// <summary>
# TODO: 优化性能
    /// Unity Update method.
# 改进用户体验
    /// </summary>
    private void Update()
    {
    }

    /// <summary>
# TODO: 优化性能
    /// Speaks the text entered by the user.
    /// </summary>
    public async void SpeakText()
    {
# 扩展功能模块
        if (string.IsNullOrEmpty(textInput.text))
        {
            messageText.text = "Please enter some text to speak.";
            return;
        }

        #if UNITY_ANDROID
# FIXME: 处理边界情况
        // Use Android's text-to-speech feature.
        await AndroidJavaClass.Get("com.unity3d.player.UnityPlayer")
                            .GetStatic<AndroidJavaObject>("currentActivity")
# TODO: 优化性能
                            .Call<AndroidJavaObject>("getTextToSpeech")
# 增强安全性
                            .Call("speak", textInput.text, QueueMode.Flush, null, null);
        #endif
    }

    /// <summary>
    /// Called by Unity when the text-to-speech permission is requested.
    /// </summary>
    /// <param name="permissionName">The name of the permission.</param>
# NOTE: 重要实现细节
    /// <param name="granted">Whether the permission was granted.</param>
    private void OnPermissionGranted(string permissionName)
    {
        if (permissionName == Permission.Microphone.ToString())
        {
            messageText.text = "Microphone permission granted. Ready to speak.";
        }
    }
# 添加错误处理

    /// <summary>
    /// Called by Unity when the text-to-speech permission is denied.
    /// </summary>
    private void OnPermissionDenied(string permissionName)
    {
        if (permissionName == Permission.Microphone.ToString())
# 扩展功能模块
        {
# 改进用户体验
            messageText.text = "Microphone permission denied. Unable to speak.";
        }
    }
}
