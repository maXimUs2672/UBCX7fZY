// 代码生成时间: 2025-09-18 10:35:43
using System;
using System.IO;
using UnityEngine;

public class FolderStructureOrganizer : MonoBehaviour
{
    // 目标文件夹路径
    private string targetFolderPath;

    void Start()
    {
        // 初始化目标文件夹路径
        targetFolderPath = Application.dataPath + "/Organized";

        // 检查目标文件夹是否存在，如果不存在则创建
        if (!Directory.Exists(targetFolderPath))
        {
            Directory.CreateDirectory(targetFolderPath);
        }

        // 调用整理文件夹结构的方法
        OrganizeFolderStructure(targetFolderPath);
    }

    // 整理文件夹结构的方法
    private void OrganizeFolderStructure(string folderPath)
    {
        try
        {
            // 获取文件夹下所有文件
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                // 根据需要对文件进行分类或移动
                // 例如，移动所有.txt文件到子文件夹
                if (Path.GetExtension(file) == ".txt")
                {
                    string newFilePath = Path.Combine(folderPath, "TextFiles", Path.GetFileName(file));
                    string newFolder = Path.GetDirectoryName(newFilePath);

                    // 如果目标文件夹不存在，则创建
                    if (!Directory.Exists(newFolder))
                    {
                        Directory.CreateDirectory(newFolder);
                    }

                    // 移动文件到新位置
                    File.Move(file, newFilePath);
                }
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Debug.LogError("Error organizing folder structure: " + ex.Message);
        }
    }

    // 可选：添加一个方法来整理子文件夹，如果需要
    private void OrganizeSubFolders(string folderPath)
    {
        try
        {
            // 获取子文件夹
            string[] subFolders = Directory.GetDirectories(folderPath);
            foreach (string subFolder in subFolders)
            {
                // 递归调用整理文件夹结构的方法
                OrganizeFolderStructure(subFolder);
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Debug.LogError("Error organizing sub folders: " + ex.Message);
        }
    }
}
