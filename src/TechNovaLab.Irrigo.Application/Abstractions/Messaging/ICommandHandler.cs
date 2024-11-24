using MediatR;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Abstractions.Messaging
{
    public interface ICommandHandler<in TCommand>
        : IRequestHandler<TCommand, Result> where TCommand : ICommand;

    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>;
}
