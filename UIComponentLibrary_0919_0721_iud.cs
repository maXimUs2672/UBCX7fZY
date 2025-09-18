// 代码生成时间: 2025-09-19 07:21:13
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用户界面组件库，提供常用的UI组件的创建和管理。
/// </summary>
public class UIComponentLibrary : MonoBehaviour
{
    /// <summary>
    /// 创建一个文本标签组件。
    /// </summary>
    /// <param name="parent">文本标签的父级GameObject。</param>
    /// <param name="text">要显示的文本。</param>
    /// <param name="position">文本标签的位置。</param>
    /// <returns>创建的文本标签组件。</returns>
    public Text CreateTextLabel(GameObject parent, string text, Vector3 position)
    {
        // 创建一个新的GameObject作为文本标签的容器
        GameObject textLabelGameObject = new GameObject("Text Label");
        
        // 设置文本标签的位置
        textLabelGameObject.transform.SetParent(parent.transform, false);
        textLabelGameObject.transform.position = position;
        
        // 添加Text组件
        Text textLabel = textLabelGameObject.AddComponent<Text>();
        textLabel.text = text;
        
        return textLabel;
    }

    /// <summary>
    /// 创建一个按钮组件。
    /// </summary>
    /// <param name="parent">按钮的父级GameObject。</param>
    /// <param name="onClickAction">按钮点击时执行的动作。</param>
    /// <param name="position">按钮的位置。</param>
    /// <param name="text">按钮上显示的文本。</param>
    /// <returns>创建的按钮组件。</returns>
    public Button CreateButton(GameObject parent, UnityEngine.Events.UnityAction onClickAction, Vector3 position, string text)
    {
        // 创建一个新的GameObject作为按钮的容器
        GameObject buttonGameObject = new GameObject("Button");
        
        // 设置按钮的位置
        buttonGameObject.transform.SetParent(parent.transform, false);
        buttonGameObject.transform.position = position;
        
        // 添加Button组件
        Button button = buttonGameObject.AddComponent<Button>();
        
        // 设置按钮点击事件
        button.onClick.AddListener(onClickAction);
        
        // 添加Text组件，并设置文本
        Text buttonText = buttonGameObject.AddComponent<Text>();
        buttonText.text = text;
        
        return button;
    }

    /// <summary>
    /// 创建一个滑动条组件。
    /// </summary>
    /// <param name="parent">滑动条的父级GameObject。</param>
    /// <param name="position">滑动条的位置。</param>
    /// <returns>创建的滑动条组件。</returns>
    public Slider CreateSlider(GameObject parent, Vector3 position)
    {
        // 创建一个新的GameObject作为滑动条的容器
        GameObject sliderGameObject = new GameObject("Slider");
        
        // 设置滑动条的位置
        sliderGameObject.transform.SetParent(parent.transform, false);
        sliderGameObject.transform.position = position;
        
        // 添加Slider组件
        Slider slider = sliderGameObject.AddComponent<Slider>();
        
        return slider;
    }

    // 可以在这里添加更多的UI组件创建方法
}
