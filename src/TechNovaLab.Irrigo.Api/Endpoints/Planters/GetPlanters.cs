using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.PlanterManagement.GetPlanters;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Planters
{
    internal sealed class GetPlanters : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("planters", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetPlantersQuery();

                Result<IEnumerable<PlanterResponse>> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Guest)
            .HasPermission("users:access")
            .WithTags(Tags.Planters);
        }
    }
}
