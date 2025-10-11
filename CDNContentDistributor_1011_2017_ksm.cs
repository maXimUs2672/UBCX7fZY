// 代码生成时间: 2025-10-11 20:17:43
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// CDN内容分发工具，用于处理文件的上传和下载。
/// </summary>
public class CDNContentDistributor
{
    /// <summary>
    /// 上传文件到CDN。
    /// </summary>
    /// <param name="filePath">本地文件路径。</param>
    /// <param name="cdnUrl">CDN服务器地址。</param>
    public IEnumerator UploadFile(string filePath, string cdnUrl)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("文件路径不能为空。");
            yield break;
        }

        if (!File.Exists(filePath))
        {
            Debug.LogError("指定的文件不存在。");
            yield break;
        }

        UnityWebRequest request = UnityWebRequest.Post(cdnUrl, "");
        request.method = "POST";
        request.uploadHandler = (UploadHandler)new UploadHandlerFile(filePath);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/octet-stream");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("文件上传失败：" + request.error);
        }
        else
        {
            Debug.Log("文件上传成功。");
        }
    }

    /// <summary>
    /// 从CDN下载文件。
    /// </summary>
    /// <param name="cdnUrl">CDN服务器地址。</param>
    /// <param name="localPath">本地存储路径。</param>
    public IEnumerator DownloadFile(string cdnUrl, string localPath)
    {
        if (string.IsNullOrEmpty(cdnUrl))
        {
            Debug.LogError("CDN服务器地址不能为空。");
            yield break;
        }

        UnityWebRequest request = UnityWebRequest.Get(cdnUrl);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("文件下载失败：" + request.error);
        }
        else
        {
            File.WriteAllBytes(localPath, request.downloadHandler.data);
            Debug.Log("文件下载成功，保存路径：" + localPath);
        }
    }
}
