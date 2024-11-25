using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.GetByEmail
{
    internal sealed class GetUserByEmailQueryHandler(
        IRepository repository, 
        IUserContext userContext) : IQueryHandler<GetUserByEmailQuery, UserResponse>
    {
        public async Task<Result<UserResponse>> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            UserResponse? user = await repository
                .Get<User>(u => u.Email == query.Email)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .SingleOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                return Result.Failure<UserResponse>(UserErrors.NotFoundByEmail);
            }

            if (user.Id != userContext.UserId)
            {
                return Result.Failure<UserResponse>(UserErrors.Unauthorized());
            }

            return user;
        }
    }
}
