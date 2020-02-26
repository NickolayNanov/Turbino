using System;
using Turbino.Domain.Entities.Common;
using Turbino.Domain.Enumerations;

namespace Turbino.Domain.Entities
{
    public class Tour : BaseModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public TourType TourType { get; set; }

        public decimal Price { get; set; }

        public string DestinationId { get; set; }

        public Destination Destination { get; set; }
    }
}
