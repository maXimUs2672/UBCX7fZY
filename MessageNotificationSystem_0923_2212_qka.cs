// 代码生成时间: 2025-09-23 22:12:48
using System;
using System.Collections.Generic;
using UnityEngine;

// 消息通知系统
public class MessageNotificationSystem : MonoBehaviour
{
    // 事件定义，用于通知
    public event Action<string> OnMessageReceived;

    // 发送消息的方法
    public void SendMessage(string message)
    {
        try
        {
            Debug.Log($"Sending message: {message}");
            OnMessageReceived?.Invoke(message); // 触发事件
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error sending message: {ex.Message}");
        }
    }

    // 注册消息接收的方法
    public void RegisterMessageReceiver(Action<string> messageReceiver)
    {
        OnMessageReceived += messageReceiver;
    }

    // 注销消息接收的方法
    public void UnregisterMessageReceiver(Action<string> messageReceiver)
    {
        OnMessageReceived -= messageReceiver;
    }

    // 消息接收处理器的示例实现
    private void OnEnable()
    {
        RegisterMessageReceiver(HandleMessage);
    }

    private void OnDisable()
    {
        UnregisterMessageReceiver(HandleMessage);
    }

    private void HandleMessage(string message)
    {
        Debug.Log($"Message received: {message}");
    }
}
