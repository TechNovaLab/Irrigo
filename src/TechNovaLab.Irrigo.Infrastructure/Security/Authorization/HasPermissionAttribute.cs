﻿using Microsoft.AspNetCore.Authorization;

namespace TechNovaLab.Irrigo.Infrastructure.Security.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
    {
    }
}
