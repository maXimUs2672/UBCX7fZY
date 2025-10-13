// 代码生成时间: 2025-10-13 19:14:05
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ComplianceTools
{
    public class ComplianceCheckTool
    {
        // Define a list to hold compliance rules
        private List<IComplianceRule> _complianceRules;

        // Constructor
        public ComplianceCheckTool()
        {
            _complianceRules = new List<IComplianceRule>();
        }

        // Method to add a compliance rule to the list
        public void AddRule(IComplianceRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule), "Compliance rule cannot be null.");
            }

            _complianceRules.Add(rule);
        }

        // Method to perform all compliance checks
        public ComplianceResult PerformChecks()
        {
            ComplianceResult result = new ComplianceResult();
            foreach (IComplianceRule rule in _complianceRules)
            {
                try
                {
                    ComplianceRuleResult ruleResult = rule.CheckCompliance();
                    result.AddRuleResult(ruleResult);
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }
            }
            return result;
        }
    }

    // Interface for compliance rules
    public interface IComplianceRule
    {
        ComplianceRuleResult CheckCompliance();
    }

    // Result class for compliance checks
    public class ComplianceResult
    {
        private List<string> _errors;
        private List<ComplianceRuleResult> _ruleResults;

        public ComplianceResult()
        {
            _errors = new List<string>();
            _ruleResults = new List<ComplianceRuleResult>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public void AddRuleResult(ComplianceRuleResult result)
        {
            _ruleResults.Add(result);
        }

        // Additional methods can be added to retrieve results or errors
    }

    // Result class for individual compliance rule checks
    public class ComplianceRuleResult
    {
        public bool IsCompliant { get; set; }
        public string Message { get; set; }
    }
}
