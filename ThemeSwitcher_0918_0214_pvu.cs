// 代码生成时间: 2025-09-18 02:14:12
using UnityEngine;
using UnityEngine.UI;

/// <summary>
# FIXME: 处理边界情况
/// ThemeSwitcher class is responsible for switching between different themes in a Unity application.
/// </summary>
public class ThemeSwitcher : MonoBehaviour
{
    /// <summary>
# 增强安全性
    /// A list of theme colors that can be used to switch themes.
    /// </summary>
    public Color[] themeColors;
# 扩展功能模块

    /// <summary>
    /// A reference to the root UI element to apply the theme changes.
    /// </summary>
    public GameObject uiRoot;
# TODO: 优化性能

    /// <summary>
    /// Switches the theme by changing the background color of the UI elements.
# TODO: 优化性能
    /// </summary>
    /// <param name="themeIndex">The index of the theme color to apply.</param>
    public void SwitchTheme(int themeIndex)
    {
        // Check if the themeIndex is within the valid range
        if (themeIndex < 0 || themeIndex >= themeColors.Length)
        {
            Debug.LogError("Theme index is out of range.");
# 优化算法效率
            return;
        }
# TODO: 优化性能

        // Apply the theme color to all UI elements
        foreach (var color in themeColors)
        {
            ApplyColorToUI(color);
        }
    }

    /// <summary>
    /// Applies the specified color to all UI elements in the UI root.
    /// </summary>
    /// <param name="color">The color to apply.</param>
    private void ApplyColorToUI(Color color)
    {
# FIXME: 处理边界情况
        // Check if the UI root is not null
        if (uiRoot == null)
        {
            Debug.LogError("UI root is not assigned.");
# 添加错误处理
            return;
        }

        // Apply the color to all Image components
        var images = uiRoot.GetComponentsInChildren<Image>();
        foreach (var img in images)
        {
# 改进用户体验
            img.color = color;
        }

        // Apply the color to all Text components
        var texts = uiRoot.GetComponentsInChildren<Text>();
# 优化算法效率
        foreach (var txt in texts)
        {
            txt.color = color;
# 扩展功能模块
        }
    }
}
