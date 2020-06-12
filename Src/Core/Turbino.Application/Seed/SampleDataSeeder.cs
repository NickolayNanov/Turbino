namespace Turbino.Application.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;

    using Common.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Turbino.Common.GlobalContants;
    using Turbino.Domain.Entities;

    public class SampleDataSeeder
    {
        private readonly ITurbinoDbContext context;
        private readonly UserManager<TurbinoUser> userManager;
        private readonly RoleManager<TurbinoRole> roleManager;

        public SampleDataSeeder(ITurbinoDbContext context, RoleManager<TurbinoRole> roleManager, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedRolesAsync(cancellationToken);
            await SeedManagersAsync(cancellationToken);
            await SeedDestinationsAsync(cancellationToken);
        }

        private async Task SeedDestinationsAsync(CancellationToken cancellationToken)
        {
            if (!context.Destinations.Any())
            {
                List<Destination> destinations = new List<Destination>()
            {
                new Destination()
                {
                    Name = "Costa Rica",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982226/cr_s3nmaw.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Switzerland",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982262/istock-546434836_npiig4.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Netherlands",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982300/shutterstock_1153213027-1200x675_tzui5n.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Japan",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982353/japan_hscfsl.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "California, USA",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982405/california_x6wmyh.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "New York, USA",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982470/ny_xgbtyt.png",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "England",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982499/england-london-big-ben-river-night_y2lhfj.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Peru",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591984964/images_wl3i2u.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "India",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591985014/asd_djybsq.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "China",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591985063/dcf1e0ec17d14df8fac9a7a57c7af63d-china_rptgph.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Australia",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591985107/106096156-1566788802677gettyimages-960670936_bife7u.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Argentina",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591985224/argie-GettyImages-539288446-xlarge_1_lyddf0.webp",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
                new Destination()
                {
                    Name = "Veliko Tarnovo",
                    ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591985269/ce98fd7605993aa8dac0c1465692ae3e-tsarevets-fortress_v98uai.jpg",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                },
            };

                await context.Destinations.AddRangeAsync(destinations);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        private async Task SeedManagersAsync(CancellationToken cancellationToken)
        {
            //var managers = new[]
            //{
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Ivan", LastName = "Ivanov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Petar", LastName = "Petrov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Sasho", LastName = "Trifonov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Lambi", LastName = "Kostov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Simeon", LastName = "Atanasov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow }
            //};
            //
            //context.Managers.AddRange(managers);
            await SeedRolesAndAdminAsync();
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRolesAsync(CancellationToken cancellationToken)
        {
            //var roles = new[]
            //{
            //    new TurbinoRole { Id = Guid.NewGuid().ToString(), Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
            //    new TurbinoRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" },
            //};
            //
            //context.TurbinoRoles.AddRange(roles);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRolesAndAdminAsync()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new TurbinoRole("Admin"));
                await roleManager.CreateAsync(new TurbinoRole("User"));
            }

            if (!userManager.Users.Any())
            {
                TurbinoUser user = new TurbinoUser() { UserName = "admin", FirstName = "admin", LastName = "adminov" };
                await userManager.CreateAsync(user, "fr3s7ed23");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
