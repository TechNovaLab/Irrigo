using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.SheduleManagement.CreateSchedule
{
    public sealed record CreateScheduleCommand(
        int SprinklerGroupId,
        TimeSpan StartTime,
        bool IsActive,
        string? Notes) : ICommand<ScheduleResponse>;
}
