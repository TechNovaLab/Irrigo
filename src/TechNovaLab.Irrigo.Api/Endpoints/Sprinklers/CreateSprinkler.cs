using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.SprinklerManagement.CreateSprinkler;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Sprinklers
{
    internal sealed class CreateSprinkler : IEndpoint
    {
        public sealed record Request(
            string Name, 
            int? SprinklerGroupId, 
            double IrrigationCapacityPerMinute);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("sprinklers/create", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateSprinklerCommand(
                    request.Name,
                    request.SprinklerGroupId,
                    request.IrrigationCapacityPerMinute);

                Result<SprinklerResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Contributor)
            .HasPermission("users:access")
            .WithTags(Tags.Sprinklers);
        }
    }
}
