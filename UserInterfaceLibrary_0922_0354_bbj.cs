// 代码生成时间: 2025-09-22 03:54:46
 * UserInterfaceLibrary.cs
 * 
 * 功能描述：
 * 这是一个Unity框架下的用户界面组件库，它实现了一个基础的用户界面组件管理器。
 * 它提供了添加、移除和获取界面组件的方法，以便于在Unity项目中重用和维护界面组件。
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用户界面组件库
/// </summary>
public class UserInterfaceLibrary : MonoBehaviour
{
    // 字典用于存储界面组件，键为组件名称，值为组件本身
    private Dictionary<string, GameObject> uiComponents = new Dictionary<string, GameObject>();

    /// <summary>
    /// 添加界面组件到库中
    /// </summary>
    /// <param name="componentName">组件的名称</param>
    /// <param name="component">要添加的组件</param>
    public void AddComponent(string componentName, GameObject component)
    {
        if (componentName == null || componentName.Trim() == "")
        {
            Debug.LogError("Component name cannot be null or empty.");
            return;
        }

        if (component == null)
        {
            Debug.LogError("Component cannot be null.");
            return;
        }

        if (uiComponents.ContainsKey(componentName))
        {
            Debug.LogWarning("Component with the same name already exists. Overwriting...");
        }

        uiComponents[componentName] = component;
        Debug.Log("Component added: " + componentName);
    }

    /// <summary>
    /// 从库中移除界面组件
    /// </summary>
    /// <param name="componentName">要移除的组件的名称</param>
    public void RemoveComponent(string componentName)
    {
        if (uiComponents.ContainsKey(componentName) && uiComponents[componentName] != null)
        {
            Destroy(uiComponents[componentName]);
            uiComponents.Remove(componentName);
            Debug.Log("Component removed: " + componentName);
        }
        else
        {
            Debug.LogWarning("Component not found: " + componentName);
        }
    }

    /// <summary>
    /// 获取界面组件
    /// </summary>
    /// <param name="componentName">要获取的组件的名称</param>
    /// <returns>返回找到的组件，如果未找到则返回null</returns>
    public GameObject GetComponent(string componentName)
    {
        if (uiComponents.TryGetValue(componentName, out GameObject component))
        {
            return component;
        }
        else
        {
            Debug.LogWarning("Component not found: " + componentName);
            return null;
        }
    }

    /// <summary>
    /// 在界面上激活一个组件
    /// </summary>
    /// <param name="componentName">要激活的组件名称</param>
    public void ActivateComponent(string componentName)
    {
        GameObject component = GetComponent(componentName);
        if (component != null)
        {
            component.SetActive(true);
            Debug.Log("Component activated: " + componentName);
        }
        else
        {
            Debug.LogWarning("Component not found or already active: " + componentName);
        }
    }

    /// <summary>
    /// 在界面上禁用一个组件
    /// </summary>
    /// <param name="componentName">要禁用的组件名称</param>
    public void DeactivateComponent(string componentName)
    {
        GameObject component = GetComponent(componentName);
        if (component != null)
        {
            component.SetActive(false);
            Debug.Log("Component deactivated: " + componentName);
        }
        else
        {
            Debug.LogWarning("Component not found or already inactive: " + componentName);
        }
    }
}
