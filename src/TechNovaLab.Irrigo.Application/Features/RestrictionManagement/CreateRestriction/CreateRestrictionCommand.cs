using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Application.Abstractions.Messaging;
using TechNovaLab.Irrigo.Domain.Entities.Restrictions;
using TechNovaLab.Irrigo.Domain.Errors;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Features.RestrictionManagement.CreateRestriction
{
    public sealed record CreateRestrictionCommand(
        string Name,
        Season Season,
        RestrictionSeverity Severity,
        double MaxWaterLimit,
        DateTime StartDate,
        DateTime EndDate,
        TimeSpan AllowedStartTime,
        TimeSpan AllowedEndTime,
        string? Reason) : ICommand<RestrictionResponse>;

    internal sealed class RestrictionCommandHandler(
        IRepository repository, 
        IUnitOfWork unitOfWork) : ICommandHandler<CreateRestrictionCommand, RestrictionResponse>
    {
        public async Task<Result<RestrictionResponse>> Handle(CreateRestrictionCommand command, CancellationToken cancellationToken)
        {
            var isOverlappingDates = await repository
                .Get<Restriction>()
                .AnyAsync(r => r.StartDate < command.EndDate && r.EndDate > command.StartDate, cancellationToken);

            if(isOverlappingDates)
            {
                Result.Failure<RestrictionResponse>(RestrictionErrors.OverlappingDates);
            }

            var restriction = new Restriction
            {
                PublicId = Guid.NewGuid(),
                Name = command.Name,
                Season = command.Season,
                Severity = command.Severity,
                MaxWaterLimit = command.MaxWaterLimit,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                AllowedStartTime = command.AllowedStartTime,
                AllowedEndTime = command.AllowedEndTime,
                Reason = command.Reason,
            };

            await repository.AddAsync(restriction, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new RestrictionResponse(
                restriction.PublicId,
                restriction.Name,
                restriction.Season,
                restriction.Severity,
                restriction.MaxWaterLimit,
                restriction.StartDate,
                restriction.EndDate,
                restriction.AllowedStartTime,
                restriction.AllowedEndTime,
                restriction.Reason);
        }
    }

    internal sealed class RestrictionCommandValidator : AbstractValidator<CreateRestrictionCommand>
    {
        public RestrictionCommandValidator()
        {
            RuleFor(x => x.Season).IsInEnum();
            RuleFor(x => x.Severity).IsInEnum();
            RuleFor(x => x.MaxWaterLimit).GreaterThan(0);
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
            RuleFor(x => x.AllowedStartTime).LessThan(x => x.AllowedEndTime);
        }
    }

    public sealed record RestrictionResponse(
        Guid PublicId,
        string Name,
        Season Season,
        RestrictionSeverity Severity,
        double MaxWaterLimit,
        DateTime StartDate,
        DateTime EndDate,
        TimeSpan AllowedStartTime,
        TimeSpan AllowedEndTime,
        string? Reason);
}
