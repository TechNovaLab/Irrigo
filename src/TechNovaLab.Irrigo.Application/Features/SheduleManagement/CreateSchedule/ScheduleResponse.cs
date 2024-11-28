namespace TechNovaLab.Irrigo.Application.Features.SheduleManagement.CreateSchedule
{
    public sealed record ScheduleResponse(
        Guid PublicId,
        int SprinklerGroupId,
        TimeSpan StartTime,
        TimeSpan EndTime,
        bool IsActive,
        string? Notes);
}
