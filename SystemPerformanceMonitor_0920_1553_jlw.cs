// 代码生成时间: 2025-09-20 15:53:52
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

/// <summary>
/// System performance monitor tool for Unity.
/// </summary>
public class SystemPerformanceMonitor : MonoBehaviour
{
    /// <summary>
# 扩展功能模块
    /// Time interval in seconds for updating performance metrics.
# NOTE: 重要实现细节
    /// </summary>
    private float updateTime = 1.0f;
# NOTE: 重要实现细节
    private float timer;
    private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    private PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    private string cpuUsage;
    private string ramUsage;

    void Start()
    {
# TODO: 优化性能
        // Initialize the performance counters.
        cpuCounter.MachineName = ".";
        ramCounter.MachineName = ".";
        timer = updateTime;
    }

    void Update()
    {
        // Update the performance metrics every 'updateTime' seconds.
        timer += Time.deltaTime;
        if (timer >= updateTime)
        {
            timer = 0;
            UpdatePerformanceMetrics();
# FIXME: 处理边界情况
        }
    }

    /// <summary>
    /// Updates the system performance metrics.
# 增强安全性
    /// </summary>
    private void UpdatePerformanceMetrics()
    {
        try
        {
            // Sample the performance counters.
            cpuUsage = cpuCounter.NextValue().ToString("0.00") + "%";
            ramUsage = ramCounter.NextValue().ToString("0.00") + " MB";

            // Log the performance metrics.
            Debug.Log($"CPU Usage: {cpuUsage}");
# 优化算法效率
            Debug.Log($"Available RAM: {ramUsage}");
        }
# 优化算法效率
        catch (Exception ex)
        {
# 优化算法效率
            // Handle any exceptions that occur during performance monitoring.
# 改进用户体验
            Debug.LogError($"Error sampling system performance metrics: {ex.Message}");
        }
    }

    /// <summary>
    /// Returns the current CPU usage as a percentage.
    /// </summary>
    /// <returns>The CPU usage as a string.</returns>
    public string GetCPUUsage()
    {
        return cpuUsage;
# 扩展功能模块
    }

    /// <summary>
# 改进用户体验
    /// Returns the current available RAM in megabytes.
    /// </summary>
    /// <returns>The RAM usage as a string.</returns>
# 添加错误处理
    public string GetRAMUsage()
    {
        return ramUsage;
    }
}
