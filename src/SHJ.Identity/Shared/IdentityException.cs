using System.Collections.Generic;

namespace SHJ.Identity.Shared;

public class IdentityException : Exception
{

    public string Code { get; set; } = string.Empty;
    public IdentityException(string code, string? message = "") : base(message)
    {
        this.Code = code;
    }
}

public static class GlobalErrorIdentity
{
    public const string Identity = "Identity";
    public const string IsLockedOut = $"{Identity}-501";
    public const string IsNotAllowed = $"{Identity}-502";
    public const string NotFoundUser = $"{Identity}-503";
    public const string AccessDenied = $"{Identity}-504";
    public const string DublicateEmail = $"{Identity}-505";
    public const string TheListOfRolesIsEmpty = $"{Identity}-506";
}

