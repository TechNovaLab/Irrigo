using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.PlanterManagement.CreatePlanter;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Planters
{
    public sealed class CreatePlanter : IEndpoint
    {
        public sealed record Request(string Name, string Description);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("planters/create-planter", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreatePlanterCommand(
                    request.Name,
                    request.Description);

                Result<PlanterResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            });
        }
    }
}
