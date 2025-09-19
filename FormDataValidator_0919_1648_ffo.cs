// 代码生成时间: 2025-09-19 16:48:12
using System;
using System.Collections.Generic;
using UnityEngine;

public class FormDataValidator
{
    // Validates that the input string is not null or empty.
    public bool ValidateString(string input, string fieldName)
    {
        if (string.IsNullOrEmpty(input))
        {
            Debug.LogError($"The field {fieldName} cannot be empty.");
            return false;
        }
        return true;
    }

    // Validates that the input email is in a correct format.
    public bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            Debug.LogError("Email address cannot be empty.");
            return false;
        }
        // Simple regex pattern for email validation.
        var emailPattern = @"^[^@]+@[^@]+\.[^@]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
    }

    // Validates that the input date is in a correct format.
    public bool ValidateDate(string date)
    {
        if (string.IsNullOrEmpty(date))
        {
            Debug.LogError("Date cannot be empty.");
            return false;
        }
        // Simple date format validation.
        // This should be replaced with a more robust date validation logic.
        var dateFormat = "yyyy-MM-dd";
        DateTime parsedDate;
        return DateTime.TryParseExact(date, dateFormat, System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out parsedDate);
    }

    // Example method to validate a form.
    public bool ValidateForm(Dictionary<string, string> formData)
    {
        bool isValid = true;

        foreach (var field in formData)
        {
            string value = field.Value;
            string fieldName = field.Key;
            switch (fieldName)
            {
                case "name":
                    isValid &= ValidateString(value, fieldName);
                    break;
                case "email":
                    isValid &= ValidateEmail(value);
                    break;
                case "date":
                    isValid &= ValidateDate(value);
                    break;
                default:
                    Debug.LogWarning($"Unrecognized field: {fieldName}");
                    break;
            }
        }

        return isValid;
    }
}
