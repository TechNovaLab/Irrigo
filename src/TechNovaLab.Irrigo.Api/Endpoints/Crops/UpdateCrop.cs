using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.CropManagement.UpdateCrop;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Crops
{
    internal sealed class UpdateCrop : IEndpoint
    {
        public sealed record Request(
            string Name,
            int PlantUnits,
            int CropTypeId,
            int PlanterId,
            int SprinklerGroupId);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("crops/update-crop/{publicId}", async (Guid publicId, Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new UpdateCropCommand(
                    publicId,
                    request.Name,
                    request.PlantUnits,
                    request.CropTypeId,
                    request.PlanterId,
                    request.SprinklerGroupId);

                Result<CropResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Member)
            .HasPermission("users:access")
            .WithTags(Tags.Crops);
        }
    }
}
