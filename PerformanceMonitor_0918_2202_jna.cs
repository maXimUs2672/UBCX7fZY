// 代码生成时间: 2025-09-18 22:02:16
using System;
using System.Diagnostics;
using UnityEngine;

public class PerformanceMonitor {

    private float cpuUsageThreshold = 90.0f; // CPU使用率阈值
    private float memoryUsageThreshold = 90.0f; // 内存使用率阈值
    private float refreshInterval = 1.0f; // 刷新间隔（秒）
    private float lastUpdate = Time.time;
    private float cpuUsage;
    private float memoryUsage;
    private bool isMonitoring;

    // 构造函数
    public PerformanceMonitor() {
        isMonitoring = true;
    }

    // 开始监控性能
    public void StartMonitoring() {
        if (!isMonitoring) {
            lastUpdate = Time.time;
            isMonitoring = true;
        }
    }

    // 停止监控性能
    public void StopMonitoring() {
        isMonitoring = false;
    }

    // 获取CPU使用率
    public float GetCpuUsage() {
        if (isMonitoring && Time.time - lastUpdate >= refreshInterval) {
            cpuUsage = CalculateCpuUsage();
            lastUpdate = Time.time;
        }
        return cpuUsage;
    }

    // 获取内存使用率
    public float GetMemoryUsage() {
        if (isMonitoring && Time.time - lastUpdate >= refreshInterval) {
            memoryUsage = CalculateMemoryUsage();
            lastUpdate = Time.time;
        }
        return memoryUsage;
    }

    // 计算CPU使用率
    private float CalculateCpuUsage() {
        float cpuPercentage = 0.0f;
        try {
            cpuPercentage = (float)System.Diagnostics.Process.GetProcesses().Length / (float)System.Environment.ProcessorCount * 100;
        } catch (Exception ex) {
            Debug.LogError("Error calculating CPU usage: " + ex.Message);
        }
        return cpuPercentage;
    }

    // 计算内存使用率
    private float CalculateMemoryUsage() {
        float memoryPercentage = 0.0f;
        try {
            // 总内存 - 可用内存
            memoryPercentage = (float)(GC.GetTotalMemory(false) - GC.GetTotalMemory(true)) / (float)GC.GetTotalMemory(false) * 100;
        } catch (Exception ex) {
            Debug.LogError("Error calculating memory usage: " + ex.Message);
        }
        return memoryPercentage;
    }

    // 更新方法，可以在Update中调用
    public void Update() {
        if (isMonitoring) {
            // 监控性能指标
            float cpu = GetCpuUsage();
            float memory = GetMemoryUsage();
            
            // 检查是否超过阈值
            if (cpu > cpuUsageThreshold) {
                Debug.LogWarning("CPU usage is high: " + cpu.ToString("0.00") + "%");
            }
            if (memory > memoryUsageThreshold) {
                Debug.LogWarning("Memory usage is high: " + memory.ToString("0.00") + "%");
            }
        }
    }
}
