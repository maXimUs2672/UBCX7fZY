// 代码生成时间: 2025-09-20 23:59:47
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A utility class that provides hash calculation functionality.
/// </summary>
public class HashCalculator
{
    /// <summary>
    /// Calculates the SHA256 hash of the provided string.
    /// </summary>
    /// <param name="input">The string to be hashed.</param>
    /// <returns>The SHA256 hash as a hexadecimal string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
    public static string CalculateSHA256Hash(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
        }

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }

    /// <summary>
    /// Calculates the MD5 hash of the provided string.
    /// </summary>
    /// <param name="input">The string to be hashed.</param>
    /// <returns>The MD5 hash as a hexadecimal string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
    public static string CalculateMD5Hash(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
        }

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
