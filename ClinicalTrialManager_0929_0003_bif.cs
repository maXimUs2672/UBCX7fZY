// 代码生成时间: 2025-09-29 00:03:01
// ClinicalTrialManager.cs

// 临床试验管理系统

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 临床试验管理器，负责管理临床试验的各个阶段和相关数据。
/// </summary>
public class ClinicalTrialManager
{
    /// <summary>
    /// 临床试验的数据模型
    /// </summary>
    private class TrialData
    {
        public string TrialId;
        public string PatientId;
        public string TrialPhase;
        public DateTime TrialDate;
    }

    /// <summary>
    /// 存储所有临床试验数据的列表
    /// </summary>
    private List<TrialData> trials;

    /// <summary>
    /// 构造函数，初始化临床试验数据列表
    /// </summary>
    public ClinicalTrialManager()
    {
        trials = new List<TrialData>();
    }

    /// <summary>
    /// 添加一个新的临床试验
    /// </summary>
    /// <param name="trialId">试验的唯一标识符</param>
    /// <param name="patientId">患者的唯一标识符</param>
    /// <param name="trialPhase">试验阶段</param>
    /// <param name="trialDate">试验日期</param>
    public void AddTrial(string trialId, string patientId, string trialPhase, DateTime trialDate)
    {
        if (string.IsNullOrEmpty(trialId) || string.IsNullOrEmpty(patientId) || string.IsNullOrEmpty(trialPhase))
        {
            Debug.LogError("Invalid trial data provided.");
            return;
        }

        var trialData = new TrialData
        {
            TrialId = trialId,
            PatientId = patientId,
            TrialPhase = trialPhase,
            TrialDate = trialDate
        };

        trials.Add(trialData);
    }

    /// <summary>
    /// 获取指定患者的所有临床试验
    /// </summary>
    /// <param name="patientId">患者的唯一标识符</param>
    /// <returns>返回匹配的临床试验列表</returns>
    public List<TrialData> GetTrialsByPatient(string patientId)
    {
        if (string.IsNullOrEmpty(patientId))
        {
            Debug.LogError("Invalid patient ID provided.");
            return null;
        }

        var result = new List<TrialData>();
        foreach (var trial in trials)
        {
            if (trial.PatientId == patientId)
            {
                result.Add(trial);
            }
        }

        return result;
    }

    /// <summary>
    /// 更新临床试验的阶段
    /// </summary>
    /// <param name="trialId">试验的唯一标识符</param>
    /// <param name="newPhase">新的试验阶段</param>
    public void UpdateTrialPhase(string trialId, string newPhase)
    {
        foreach (var trial in trials)
        {
            if (trial.TrialId == trialId)
            {
                trial.TrialPhase = newPhase;
                return;
            }
        }

        Debug.LogError("Trial not found with ID: " + trialId);
    }

    /// <summary>
    /// 删除一个临床试验
    /// </summary>
    /// <param name="trialId">试验的唯一标识符</param>
    public void RemoveTrial(string trialId)
    {
        var trialToRemove = trials.Find(t => t.TrialId == trialId);
        if (trialToRemove != null)
        {
            trials.Remove(trialToRemove);
        }
        else
        {
            Debug.LogError("Trial not found with ID: " + trialId);
        }
    }
}
