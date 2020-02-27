using System;
using System.Collections.Generic;
using Turbino.Domain.Entities.Common;
using Turbino.Domain.Enumerations;

namespace Turbino.Domain.Entities
{
    public class Tour : BaseModel
    {
        public Tour()
        {
            this.Reviews = new HashSet<Review>();
        }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public TourType TourType { get; set; }

        public int Duration { get; set; }

        public int RequiredAge { get; set; }

        public int Included { get; set; }

        public decimal Price { get; set; }

        public string DestinationId { get; set; }

        public Destination Destination { get; set; }

        public virtual ICollection<Review> Reviews { get; private set; }

        public virtual ICollection<TourImage> Galery { get; private set; }
    }
}
