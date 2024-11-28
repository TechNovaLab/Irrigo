using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.SheduleManagement.CreateSchedule;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Schedules
{
    internal class CreateSchedule : IEndpoint
    {
        public sealed record Request(
            int SprinklerGroupId,
            TimeSpan StartTime,
            bool IsActive,
            string? Notes);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("schedules/create-schedule", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateScheduleCommand(
                    request.SprinklerGroupId,
                    request.StartTime,
                    request.IsActive,
                    request.Notes);

                Result<ScheduleResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            });
        }
    }
}
