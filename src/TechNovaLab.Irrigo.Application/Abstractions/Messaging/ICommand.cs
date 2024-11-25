using MediatR;
using TechNovaLab.Irrigo.SharedKernel.Core;

namespace TechNovaLab.Irrigo.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommnand;

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommnand;

    public interface IBaseCommnand;
}
