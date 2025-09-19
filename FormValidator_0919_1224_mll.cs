// 代码生成时间: 2025-09-19 12:24:39
// FormValidator.cs
// Form data validator for Unity applications, ensuring data integrity and providing error handling.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class for validating form data in a Unity application.
/// </summary>
public class FormValidator
{
    private Dictionary<string, string> errors = new Dictionary<string, string>();

    /// <summary>
    /// Validate the form data.
    /// </summary>
    /// <param name="formData">Dictionary containing form data.</param>
    /// <returns>True if the form is valid, otherwise false.</returns>
    public bool ValidateForm(Dictionary<string, string> formData)
    {
        errors.Clear();

        foreach (var entry in formData)
        {
            if (string.IsNullOrEmpty(entry.Value))
            {
                AddError(entry.Key, "Field cannot be empty.");
            }
            else if (entry.Key == "Email" && !IsValidEmail(entry.Value))
            {
                AddError(entry.Key, "Invalid email address.");
            }
        }

        return errors.Count == 0;
    }

    /// <summary>
    /// Adds an error message to the errors dictionary.
    /// </summary>
    /// <param name="field">Name of the field with the error.</param>
    /// <param name="message">Error message.</param>
    private void AddError(string field, string message)
    {
        errors[field] = message;
    }

    /// <summary>
    /// Checks if the provided email address is valid.
    /// </summary>
    /// <param name="email">Email address to validate.</param>
    /// <returns>True if the email is valid, otherwise false.</returns>
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Retrieves the error messages associated with invalid fields.
    /// </summary>
    /// <returns>Dictionary of field names and their corresponding error messages.</returns>
    public Dictionary<string, string> GetErrors()
    {
        return errors;
    }
}
