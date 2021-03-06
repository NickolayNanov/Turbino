﻿namespace Turbino.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    
    using Domain.Entities;
    using Application.Common.Interfaces;

    using Turbino.Persistence.Common;

    public class TurbinoDbContext : IdentityDbContext<TurbinoUser, TurbinoRole, string>, ITurbinoDbContext
    {
        public DbSet<Tour> Tours { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<UserDestination> UserDestinations { get; set; }

        public DbSet<TourImage> TourImages { get; set; }

        public DbSet<DestinationImage> DestinationImages { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<TurbinoUserRole> UserRoles { get; set; }

        public DbSet<TurbinoUser> Users { get; set; }

        public DbSet<TurbinoRole> Roles { get; set; }


        public TurbinoDbContext(DbContextOptions<TurbinoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(TurbinoDbContext).Assembly);            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomSqlServerMigrationsSqlGenerator>();
        }        
    }    
}