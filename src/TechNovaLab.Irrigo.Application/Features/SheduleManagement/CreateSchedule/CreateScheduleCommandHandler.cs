using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Schedules;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.SheduleManagement.CreateSchedule
{
    internal sealed class CreateScheduleCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateScheduleCommand, ScheduleResponse>
    {
        public async Task<Result<ScheduleResponse>> Handle(CreateScheduleCommand command, CancellationToken cancellationToken)
        {
            var schedules = await repository
                .Get<Schedule>(x => x.SprinklerGroupId == command.SprinklerGroupId)
                .ToListAsync(cancellationToken);

            if (schedules.Count == 0)
            {
                return Result.Failure<ScheduleResponse>(
                    ScheduleErrors.NotFound(nameof(Schedule), command.SprinklerGroupId));
            }

            var anyActiveSprinklerGroupConflict = schedules.Exists(x => x.IsActive);

            if (anyActiveSprinklerGroupConflict)
            {
                return Result.Failure<ScheduleResponse>(ScheduleErrors.SprinklerGroupConflict);
            }

            var schedule = new Schedule
            {
                PublicId = Guid.NewGuid(),
                SprinklerGroupId = command.SprinklerGroupId,
                StartTime = command.StartTime,
                IsActive = command.IsActive,
                Notes = command.Notes,
            };

            await repository.AddAsync(schedule, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new ScheduleResponse(
                schedule.PublicId,
                schedule.SprinklerGroupId,
                schedule.StartTime,
                schedule.EndTime,
                schedule.IsActive,
                schedule.Notes);
        }
    }
}
