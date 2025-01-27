﻿using Microsoft.EntityFrameworkCore;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Domain.Entities.Crops;
using TechNovaLab.Irrigo.Domain.Entities.Histories;
using TechNovaLab.Irrigo.Domain.Entities.Planters;
using TechNovaLab.Irrigo.Domain.Entities.Restrictions;
using TechNovaLab.Irrigo.Domain.Entities.Schedules;
using TechNovaLab.Irrigo.Domain.Entities.Sprinklers;
using TechNovaLab.Irrigo.Domain.Entities.Users;
using TechNovaLab.Irrigo.Infrastructure.Database.Abstractions;
using TechNovaLab.Irrigo.Infrastructure.Database.Configurators;

namespace TechNovaLab.Irrigo.Infrastructure.Database.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContextBase(options), IApplicationDbContext
    {
        public DbSet<Crop> Crops { get; set; } = default!;
        public DbSet<CropType> CropTypes { get; set; } = default!;
        public DbSet<History> Histories { get; set; } = default!;
        public DbSet<Restriction> Restrictions { get; set; } = default!;
        public DbSet<Schedule> Schedules { get; set; } = default!;
        public DbSet<Planter> Planters { get; set; } = default!;
        public DbSet<Sprinkler> Sprinklers { get; set; } = default!;
        public DbSet<SprinklerGroup> SprinklerGroups { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyModelConfiguration();
            modelBuilder.HasDefaultSchema(Schemas.Default);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
