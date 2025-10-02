// 代码生成时间: 2025-10-03 02:04:33
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple membership management system using C# and Unity framework.
/// </summary>
public class MembershipManager : MonoBehaviour
{
    private List<Member> members = new List<Member>();

    /// <summary>
    /// Adds a new member to the system.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <param name="email">The email of the member.</param>
    /// <returns>True if the member was added successfully, otherwise false.</returns>
    public bool AddMember(string name, string email)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
        {
            Debug.LogError("Invalid member data provided.");
            return false;
        }

        var existingMember = members.Find(m => m.Email == email);
        if (existingMember != null)
        {
            Debug.LogError("A member with the same email already exists.");
            return false;
        }

        members.Add(new Member(name, email));
        Debug.Log("Member added successfully.");
        return true;
    }

    /// <summary>
    /// Removes a member from the system by their email.
    /// </summary>
    /// <param name="email">The email of the member to remove.</param>
    /// <returns>True if the member was removed successfully, otherwise false.</returns>
    public bool RemoveMember(string email)
    {
        var member = members.Find(m => m.Email == email);
        if (member == null)
        {
            Debug.LogError("Member not found.");
            return false;
        }

        members.Remove(member);
        Debug.Log("Member removed successfully.");
        return true;
    }

    /// <summary>
    /// Finds a member by their email.
    /// </summary>
    /// <param name="email">The email of the member to find.</param>
    /// <returns>The member if found, otherwise null.</returns>
    public Member FindMember(string email)
    {
        return members.Find(m => m.Email == email);
    }

    /// <summary>
    /// Updates a member's information.
    /// </summary>
    /// <param name="email">The email of the member to update.</param>
    /// <param name="newName">The new name of the member.</param>
    /// <param name="newEmail">The new email of the member.</param>
    /// <returns>True if the member was updated successfully, otherwise false.</returns>
    public bool UpdateMember(string email, string newName, string newEmail)
    {
        var member = members.Find(m => m.Email == email);
        if (member == null)
        {
            Debug.LogError("Member not found.");
            return false;
        }

        if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newEmail))
        {
            Debug.LogError("Invalid new member data provided.");
            return false;
        }

        var existingMember = members.Find(m => m.Email == newEmail);
        if (existingMember != null && existingMember != member)
        {
            Debug.LogError("A member with the new email already exists.");
            return false;
        }

        member.Name = newName;
        member.Email = newEmail;
        Debug.Log("Member updated successfully.");
        return true;
    }

    /// <summary>
    /// Represents a member in the membership system.
    /// </summary>
    private class Member
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
