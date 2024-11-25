using MediatR;
using TechNovaLab.Irrigo.Api.Extensions;
using TechNovaLab.Irrigo.Api.Infrastructure;
using TechNovaLab.Irrigo.Application.Features.UserManagement.GetByEmail;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Api.Endpoints.Users
{
    internal sealed class GetByEmail : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("users/{email}", async (string email, ISender sender, CancellationToken cancellationToken) =>
            {
                var query = new GetUserByEmailQuery(email);

                Result<UserResponse> result = await sender.Send(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasRole(Role.Member)
            .HasPermission("users:read/write")
            .WithTags(Tags.Users);
        }
    }
}
