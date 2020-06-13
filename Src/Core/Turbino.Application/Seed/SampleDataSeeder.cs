namespace Turbino.Application.Seed
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Turbino.Domain.Entities;
    using Turbino.Domain.Enumerations;
    using Turbino.Common.GlobalContants;

    using Common.Interfaces;

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
            await SeedRolesAndAdminAsync();
            await SeedDestinationsAsync(cancellationToken);
            await SeedToursAsync(cancellationToken);
        }

        private async Task SeedToursAsync(CancellationToken cancellationToken)
        {
            if (!context.Tours.Any())
            {
                List<Destination> destinations = context.Destinations.Take(3).ToList();

                List<Tour> tours = new List<Tour>
                {
                    new Tour()
                    {
                        Name = "Delightful China",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1592029154/csm_AdobeStock_100408242_ec82805479_gwrv6k.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[0].Id
                    },
                    new Tour()
                    {
                        Name = "WeedLand",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1592029387/shutterstock_1028628301_atc0y9.png",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[1].Id
                    },
                    new Tour()
                    {
                        Name = "Tsarevets",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1583854581/yz2emfvtgsqt8d5aw6zk.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[0].Id
                    },
                    new Tour()
                    {
                        Name = "Random Place on Earth",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982226/cr_s3nmaw.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[1].Id
                    },
                    new Tour()
                    {
                        Name = "Another Random Place",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982300/shutterstock_1153213027-1200x675_tzui5n.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[0].Id
                    },
                    new Tour()
                    {
                        Name = "Nice beach in California",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982405/california_x6wmyh.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[1].Id
                    },
                    new Tour()
                    {
                        Name = "River",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1583854457/fzr8zytrvupznv3ghfge.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[0].Id
                    },
                    new Tour()
                    {
                        Name = "Park in USA",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1585988629/lwvhowvvurnobdejxbzr.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[1].Id
                    },
                    new Tour()
                    {
                        Name = "A walk by horse",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1585988631/obfy5v9r6rbwqhuxqzo9.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[2].Id
                    },
                    new Tour()
                    {
                        Name = "Japan with love",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982353/japan_hscfsl.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[0].Id
                    },
                    new Tour()
                    {
                        Name = "Town in heaven",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982470/ny_xgbtyt.png",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[2].Id
                    },
                    new Tour()
                    {
                        Name = "China and evryone else",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591985063/dcf1e0ec17d14df8fac9a7a57c7af63d-china_rptgph.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[1].Id
                    },
                    new Tour()
                    {
                        Name = "Nature habitat",
                        ImgUrl = "https://res.cloudinary.com/olympiacloudinary/image/upload/v1591982262/istock-546434836_npiig4.jpg",
                        PricePerPerson = 100,
                        RequiredAge = 18,
                        Duration = 7,
                        Location = "Somewhere in the world...",
                        Dates = "March, April, June",
                        Departure = "At the airport",
                        NextDeparture = "Second airport",
                        Accommodation = "All Inclusive",
                        Included = "Travel Insurance, Non-stop flight to Amsterdam, Two days long City tour, Anne Frank Museum ticket",
                        NotIncluded = "Reservation Fees (U$D25), Aerial Fees (U$D55)",
                        Description = ApplicationConstants.DestinationDescription,
                        TourType = TourType.Adventure,
                        DestinationId = destinations[0].Id
                    },
                };

                await context.Tours.AddRangeAsync(tours);
                await context.SaveChangesAsync(cancellationToken);
            }
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
