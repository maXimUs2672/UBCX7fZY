// 代码生成时间: 2025-09-22 10:19:22
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

// 定义RESTful API接口示例
public class RestfulApiExample : MonoBehaviour
{
    // API的基础URL
    private const string baseUrl = "https://api.example.com/";

    // 获取数据示例
    public IEnumerator GetExampleData(string endpoint)
    {
        try
        {
            // 使用UnityWebRequest发送GET请求
            using (UnityWebRequest webRequest = UnityWebRequest.Get(baseUrl + endpoint))
            {
                // 发送请求
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError || webRequest.isHttpError)
                {
                    Debug.LogError("Error: " + webRequest.error);
                }
                else
                {
                    // 处理返回的数据
                    Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }

    // 发送数据示例
    public IEnumerator PostExampleData(string endpoint, string jsonData)
    {
        try
        {
            // 使用UnityWebRequest发送POST请求
            using (UnityWebRequest webRequest = UnityWebRequest.Post(baseUrl + endpoint, jsonData))
            {
                // 设置请求的头部
                webRequest.SetRequestHeader("Content-Type", "application/json");

                // 发送请求
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError || webRequest.isHttpError)
                {
                    Debug.LogError("Error: " + webRequest.error);
                }
                else
                {
                    // 处理返回的数据
                    Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }
}
