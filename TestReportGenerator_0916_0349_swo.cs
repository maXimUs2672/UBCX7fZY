// 代码生成时间: 2025-09-16 03:49:57
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// 测试报告生成器类
public class TestReportGenerator
{
    private const string ReportFilePath = "TestReport.txt"; // 测试报告文件路径
    private StringBuilder reportBuilder; // 报告内容构建器

    public TestReportGenerator()
    {
        reportBuilder = new StringBuilder();
    }

    // 添加测试结果到报告
    public void AddTestResult(string testName, bool isPassed, string message)
    {
        try
        {
            reportBuilder.AppendLine($"Test Name: {testName}");
            reportBuilder.AppendLine($"Is Passed: {isPassed}");
            reportBuilder.AppendLine($"Message: {message}");
            reportBuilder.AppendLine("---------------");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to add test result: {ex.Message}");
        }
    }

    // 生成测试报告
    public void GenerateReport()
    {
        try
        {
            string reportContent = reportBuilder.ToString();
            File.WriteAllText(ReportFilePath, reportContent);
            Debug.Log($"Test report generated at: {ReportFilePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to generate report: {ex.Message}");
        }
    }
}
