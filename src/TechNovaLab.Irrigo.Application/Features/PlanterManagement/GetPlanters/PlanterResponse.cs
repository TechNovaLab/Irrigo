﻿namespace TechNovaLab.Irrigo.Application.Features.PlanterManagement.GetPlanters
{
    public sealed record PlanterResponse
    {
        public int Id { get; init; }
        public Guid PublicId { get; init; }
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
    }
}