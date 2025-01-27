﻿namespace TechNovaLab.Irrigo.Application.Features.UserManagement.GetByEmail
{
    public sealed record UserResponse
    {
        public Guid Id { get; init; }

        public string Email { get; init; } = default!;

        public string FirstName { get; init; } = default!;

        public string LastName { get; init; } = default!;
    }
}
