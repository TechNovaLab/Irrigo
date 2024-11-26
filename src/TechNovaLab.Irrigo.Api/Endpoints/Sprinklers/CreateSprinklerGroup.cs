using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinklerGroup;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Sprinklers
{
    internal sealed class CreateSprinklerGroup : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("sprinklers/create-group", async (ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateSprinklerGroupCommand();
                Result<SprinklerGroupResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Contributor)
            .HasPermission("users:access")
            .WithTags(Tags.Sprinklers);
        }
    }
}
