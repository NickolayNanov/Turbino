namespace Turbino.Application.Destinations.Queries.GetDestinationById
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Turbino.Domain.Entities;
    using System.Collections.Generic;

    public class DestinationViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int TimesVisited { get; set; }

        public string Description { get; set; }

        public string SpokenLanguage { get; set; }

        public string Visa { get; set; }

        public string Currency { get; set; }

        public int SquareArea { get; set; }

        public string ImgUrl { get; set; }

        public IList<string> Galery { get; set; }

        public static DestinationViewModel Create(Destination destination)
        {
            return Projection.Compile().Invoke(destination);
        }

        private static Expression<Func<Destination, DestinationViewModel>> Projection
        {
            get
            {
                return destination => new DestinationViewModel
                {
                    Id = destination.Id,
                    Name = destination.Name,
                    TimesVisited = destination.TimesVisited,
                    Description = destination.Description,
                    SpokenLanguage = destination.SpokenLanguage,
                    Visa = destination.Visa,
                    Currency = destination.Currency,
                    SquareArea = destination.SquareArea,
                    ImgUrl = destination.ImgUrl,
                    Galery = destination.Galery.Select(i => i.Url).ToList()
                };
            }
        }
    }
}
