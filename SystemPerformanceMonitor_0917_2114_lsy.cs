// 代码生成时间: 2025-09-17 21:14:46
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class SystemPerformanceMonitor : MonoBehaviour
{
    private float updateInterval = 2.0f; // 更新间隔
    private float timeSinceLastUpdate;

    private void Start()
    {
        // 初始化性能监控器
        Debug.Log("System Performance Monitor initialized.");
    }

    private void Update()
    {
        // 计算时间差
        timeSinceLastUpdate += Time.deltaTime;

        // 检查是否到达更新间隔
        if (timeSinceLastUpdate >= updateInterval)
        {
            // 更新系统性能数据
            UpdateSystemPerformanceData();

            // 重置时间计数器
            timeSinceLastUpdate = 0f;
        }
    }

    private void UpdateSystemPerformanceData()
    {
        try
        {
            // 获取CPU使用率
            float cpuUsage = System.Diagnostics.Process.GetCurrentProcess()
                .TotalProcessorTime.TotalMilliseconds / (Environment.ProcessorCount * 1000);
            Debug.Log($"CPU Usage: {cpuUsage}%");

            // 获取内存使用情况
            float memoryUsage = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024);
            Debug.Log($"Memory Usage: {memoryUsage} MB");

            // 可以添加更多性能监控代码
        }
        catch (Exception e)
        {
            // 错误处理
            Debug.LogError($"Error updating system performance data: {e.Message}");
        }
    }

    // 其他辅助方法可以在这里添加
}
