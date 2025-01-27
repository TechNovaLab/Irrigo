﻿using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.Histories;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Entities.Restrictions;
using TechNovaLab.Irrigo.Domain.Entities.Schedules;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Entities.Users;

namespace TechNovaLab.Irrigo.Application.Abstractions.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Crop> Crops { get; }
        DbSet<CropType> CropTypes { get; }
        DbSet<History> Histories { get; }
        DbSet<Restriction> Restrictions { get; }
        DbSet<Schedule> Schedules { get; }
        DbSet<Planter> Planters { get; }
        DbSet<Sprinkler> Sprinklers { get; }
        DbSet<SprinklerGroup> SprinklerGroups { get; }
        DbSet<User> Users { get; }
    }
}
