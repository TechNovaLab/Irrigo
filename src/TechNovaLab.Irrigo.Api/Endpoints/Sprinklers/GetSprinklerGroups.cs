using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.SprinklerManagement.GetSprinklerGroups;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Sprinklers
{
    internal sealed class GetSprinklerGroups : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("sprinklers/sprinkler-groups", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetSprinklerGroupsQuery();

                Result<IEnumerable<SprinklerGroupResponse>> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Guest)
            .HasPermission("users:access")
            .WithTags(Tags.Sprinklers);
        }
    }
}
