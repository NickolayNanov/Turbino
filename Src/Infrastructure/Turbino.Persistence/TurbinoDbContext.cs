namespace Turbino.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    
    using Domain.Entities;
    using Turbino.Persistence.Common;
    using Application.Common.Interfaces;

    public class TurbinoDbContext : IdentityDbContext, ITurbinoDbContext
    {
        public DbSet<Manager> Managers { get; set; }

        public DbSet<TurbinoRole> TurbinoRoles { get; set; }

        public DbSet<TurbinoUser> TurbinoUsers { get; set; }

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