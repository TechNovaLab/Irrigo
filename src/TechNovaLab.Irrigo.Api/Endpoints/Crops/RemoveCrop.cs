using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.CropManagement.RemoveCrop;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Crops
{
    internal sealed class RemoveCrop : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("crops/remove-crop/{publicId}", async (Guid publicId, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new RemoveCropCommand(publicId);

                Result<RemoveCropResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Member)
            .HasPermission("users:access")
            .WithTags(Tags.Crops);
        }
    }
}