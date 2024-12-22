using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinklerGroup;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Sprinklers
{
    public sealed record Request(string Name);

    internal sealed class CreateSprinklerGroup : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("sprinklers/create-group", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateSprinklerGroupCommand(request.Name);
                Result<SprinklerGroupResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Member)
            .HasPermission("users:access")
            .WithTags(Tags.Sprinklers);
        }
    }
}
