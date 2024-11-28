using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.RestrictionManagement.CreateRestriction;
using TechNovaLab.Irrigo.Domain.Entities.Restrictions;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Restrictions
{
    internal sealed class CreateRestriction : IEndpoint
    {
        public sealed record Request(
            string Name,
            Season Season,
            RestrictionSeverity Severity,
            double MaxWaterLimit,
            DateTime StartDate,
            DateTime EndDate,
            TimeSpan AllowedStartTime,
            TimeSpan AllowedEndTime,
            string? Reason);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("restrictions/create-restriction", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateRestrictionCommand(
                    request.Name,
                    request.Season,
                    request.Severity,
                    request.MaxWaterLimit,
                    request.StartDate,
                    request.EndDate,
                    request.AllowedStartTime,
                    request.AllowedEndTime,
                    request.Reason);

                Result<RestrictionResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            });
        }
    }
}
