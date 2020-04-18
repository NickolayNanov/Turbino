using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Turbino.Domain.Entities;

namespace Turbino.Application.Tours.Queries.SelectById
{
    public class TourViewModel
    {
        public string Name { get; set; }

        public decimal PricePerPerson { get; set; }

        public int RequiredAge { get; set; }

        public int Duration { get; set; }

        public string Location { get; set; }

        public string Dates { get; set; }

        public string Departure { get; set; }

        public string NextDeparture { get; set; }

        public string Accommodation { get; set; }

        public string TourType { get; set; }

        public string Description { get; set; }

        public IList<string> Included { get; set; }

        public IList<string> NotIncluded { get; set; }
    }
}
