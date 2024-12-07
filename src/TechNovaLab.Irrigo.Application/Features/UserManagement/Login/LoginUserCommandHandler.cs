using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Login
{
    internal sealed class LoginUserCommandHandler(
        IRepository repository, 
        IPasswordHasher passwordHasher, 
        ITokenProvider tokenProvider) : ICommandHandler<LoginUserCommand, UserResponse>
    {
        public async Task<Result<UserResponse>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            User? user = await repository
                .Get<User>(x => x.Email == command.Email)
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                return Result.Failure<UserResponse>(UserErrors.NotFoundByEmail);
            }

            bool verified = passwordHasher.Verify(command.Password, user.PasswordHash);

            if (!verified)
            {
                return Result.Failure<UserResponse>(UserErrors.NotFoundByEmail);
            }

            string token = tokenProvider.Create(user);

            return new UserResponse(
                user.Id, 
                user.Email,
                user.FirstName,
                user.LastName,
                user.Role,
                token);
        }
    }
}
