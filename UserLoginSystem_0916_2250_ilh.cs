// 代码生成时间: 2025-09-16 22:50:18
using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 用户登录验证系统
/// </summary>
public class UserLoginSystem : MonoBehaviour
{
    /// <summary>
    /// 用户信息数据库模拟
    /// </summary>
    private Dictionary<string, string> userDatabase = new Dictionary<string, string>
    {
        { "user1", "password1" },
        { "user2", "password2" }
    };

    void Start()
    {
        // 启动时执行任何初始化操作
    }

    /// <summary>
    /// 用户登录验证方法
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>登录成功返回true，失败返回false</returns>
    public bool Login(string username, string password)
    {
        try
        {
            // 检查用户名是否存在
            if (userDatabase.ContainsKey(username))
            {
                // 检查密码是否匹配
                if (userDatabase[username] == password)
                {
                    Debug.Log($"登录成功: {username}");
                    return true;
                }
                else
                {
                    Debug.LogError($"登录失败: 密码错误");
                    return false;
                }
            }
            else
            {
                Debug.LogError($"登录失败: 用户名不存在");
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"登录过程中发生异常: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 注册新用户
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>注册成功返回true，失败返回false</returns>
    public bool Register(string username, string password)
    {
        try
        {
            if (userDatabase.ContainsKey(username))
            {
                Debug.LogError($"注册失败: 用户名 {username} 已存在");
                return false;
            }
            else
            {
                userDatabase.Add(username, password);
                Debug.Log($"注册成功: {username}");
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"注册过程中发生异常: {ex.Message}");
            return false;
        }
    }
}
