using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.HistoryManagement.StoreSession;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.History
{
    internal sealed class StoreSession : IEndpoint
    {
        public sealed record Request(
            int SprinklerGroupId,
            double WaterUsed,
            int DurationInMinutes);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("histories/store-session", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new StoreSessionCommand(
                    request.SprinklerGroupId,
                    request.WaterUsed,
                    request.DurationInMinutes);

                Result<HistoryResponse> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            });
        }
    }
}
