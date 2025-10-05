// 代码生成时间: 2025-10-06 02:21:24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GestureRecognition 类用于识别和处理触摸手势。
/// </summary>
public class GestureRecognition : MonoBehaviour
{
    // 存储当前触摸点的列表
    private List<Touch> touchPoints = new List<Touch>();

    void Update()
    {
        // 检查是否启用了触摸输入
        if (Input.touchSupported && Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // 将每个触摸点添加到列表中
                touchPoints.Add(touch);
            }

            // 处理触摸手势
            HandleGestures();
        }
    }

    /// <summary>
    /// 处理触摸手势
    /// </summary>
    private void HandleGestures()
    {
        // 假设我们识别两个手势：单点触摸和多点触摸
        if (touchPoints.Count == 1)
        {
            // 处理单点触摸手势
            HandleSingleTouch();
        }
        else if (touchPoints.Count >= 2)
        {
            // 处理多点触摸手势
            HandleMultipleTouches();
        }
    }

    /// <summary>
    /// 处理单点触摸手势
    /// </summary>
    private void HandleSingleTouch()
    {
        // 获取第一个触摸点
        Touch touch = touchPoints[0];

        // 检查触摸阶段
        switch (touch.phase)
        {
            case TouchPhase.Began:
                Debug.Log("Single touch began at position: " + touch.position);
                break;
            case TouchPhase.Moved:
                Debug.Log("Single touch moved to position: " + touch.position);
                break;
            case TouchPhase.Ended:
                Debug.Log("Single touch ended at position: " + touch.position);
                break;
            default:
                // 未知阶段
                Debug.LogError("Unknown touch phase encountered.