﻿namespace TechNovaLab.Irrigo.Application.Features.CropManagement.CreateCrop
{
    public sealed record CropResponse(
        Guid PublicId,
        string Name,
        int PlantUnits,
        int CropTypeId,
        int PlanterId,
        int SprinklerGroupId);
}
