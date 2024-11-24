using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Events.Users;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.UserManagement.Register
{
    internal sealed class RegisterUserCommandHandler(
        IRepository repository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher) : ICommandHandler<RegisterUserCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var anyUser = await repository
                .Get<User>()
                .AnyAsync(x => x.Email == command.Email, cancellationToken);

            if (anyUser)
            {
                return Result.Failure<Guid>(UserErrors.EmailNotUnique);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Role = Role.Member,
                PasswordHash = passwordHasher.Hash(command.Password)
            };

            user.Raise(new UserRegisteredDomainEvent(user.Id));

            await repository.AddAsync(user, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return user.Id;
        }
    }
}
