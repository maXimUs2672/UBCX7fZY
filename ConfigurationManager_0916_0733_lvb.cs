// 代码生成时间: 2025-09-16 07:33:20
using System;
using System.IO;
using UnityEngine;

public class ConfigurationManager
{
    private const string ConfigFileName = "config.json";
    private string configFilePath;

    public ConfigurationManager(string configDirectory)
    {
        // 设置配置文件的路径
        configFilePath = Path.Combine(configDirectory, ConfigFileName);
    }

    /*
     * 加载配置文件
     * @return 配置文件内容
     */
    public string LoadConfig()
    {
        try
        {
            // 检查配置文件是否存在
            if (!File.Exists(configFilePath))
            {
                Debug.LogError("Configuration file not found.");
                return null;
            }

            // 读取配置文件内容
            string configContent = File.ReadAllText(configFilePath);
            Debug.Log("Configuration loaded successfully.");
            return configContent;
        }
        catch (Exception ex)
        {
            // 处理加载配置文件时的错误
            Debug.LogError($"Failed to load configuration: {ex.Message}");
            return null;
        }
    }

    /*
     * 保存配置文件
     * @param configContent 要保存的配置内容
     * @return 是否成功保存
     */
    public bool SaveConfig(string configContent)
    {
        try
        {
            // 检查配置文件路径是否有效
            if (string.IsNullOrEmpty(configFilePath))
            {
                Debug.LogError("Configuration file path is not set.");
                return false;
            }

            // 写入配置文件内容
            File.WriteAllText(configFilePath, configContent);
            Debug.Log("Configuration saved successfully.");
            return true;
        }
        catch (Exception ex)
        {
            // 处理保存配置文件时的错误
            Debug.LogError($"Failed to save configuration: {ex.Message}");
            return false;
        }
    }
}
