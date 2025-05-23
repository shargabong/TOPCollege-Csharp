﻿public class User
{
    public int UserId { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"ID: {UserId}, Login: {Login}, Name: {FullName}, Role: {Role}, Blocked: {IsBlocked}, Created: {CreatedAt}";

    }
}