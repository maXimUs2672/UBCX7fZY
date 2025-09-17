// 代码生成时间: 2025-09-17 16:34:16
using System;

// 用户类
public class User
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool IsAdmin { get; private set; }

    // 用户构造函数
    public User(string username, string password, bool isAdmin)
    {
        Username = username;
        Password = password;
        IsAdmin = isAdmin;
    }
}

// 访问控制类
public class AccessControl
{
    private User currentUser;

    // 设置当前用户
    public void SetCurrentUser(User user)
    {
        // 检查用户是否为null
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "用户不能为空");
        }

        currentUser = user;
    }

    // 检查用户是否有权限
    public bool HasPermission(string action)
    {
        // 如果用户未登录，抛出异常
        if (currentUser == null)
        {
            throw new InvalidOperationException("用户未登录");
        }

        // 默认情况下，只有管理员有权限执行所有操作
        // 可以根据需要扩展权限检查逻辑
        return currentUser.IsAdmin || action == "View";
    }
}

// 程序主入口
public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 创建用户实例
            User adminUser = new User("admin", "password", true);
            User normalUser = new User("user", "password", false);

            // 创建访问控制实例
            AccessControl accessControl = new AccessControl();

            // 设置当前用户为管理员
            accessControl.SetCurrentUser(adminUser);
            Console.WriteLine("管理员尝试执行操作：");
            Console.WriteLine($"管理员是否有权限查看？ {accessControl.HasPermission("View")}
