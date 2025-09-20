// 代码生成时间: 2025-09-20 19:40:21
///http_request_handler.cs
using System;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// HTTP请求处理器，处理HTTP请求和响应。
/// </summary>
public class HttpRequestHandler
{
    /// <summary>
    /// 发送GET请求到指定的URL。
    /// </summary>
    /// <param name="url">请求的URL地址。</param>
    /// <returns>返回请求的结果。</returns>
    public IEnumerator SendGetRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            yield return null;
        }
        else
        {
            string responseData = request.downloadHandler.text;
            Debug.Log(responseData);
            // 处理响应数据
        }
    }
    
    /// <summary>
    /// 发送POST请求到指定的URL，并附带请求体。
    /// </summary>
    /// <param name="url">请求的URL地址。</param>
    /// <param name="json">请求体的JSON字符串。</param>
    /// <returns>返回请求的结果。</returns>
    public IEnumerator SendPostRequest(string url, string json)
    {
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
            yield return null;
        }
        else
        {
            string responseData = request.downloadHandler.text;
            Debug.Log(responseData);
            // 处理响应数据
        }
    }
}
