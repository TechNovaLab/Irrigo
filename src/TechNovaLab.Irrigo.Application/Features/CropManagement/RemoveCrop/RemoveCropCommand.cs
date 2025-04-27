using TechNovaLab.Irrigo.Application.Abstractions.Messaging;

namespace TechNovaLab.Irrigo.Application.Features.CropManagement.RemoveCrop
{
    public sealed record RemoveCropCommand(Guid PublicId) : ICommand<RemoveCropResponse>;
}
