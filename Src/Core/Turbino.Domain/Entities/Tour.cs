namespace Turbino.Domain.Entities
{
    using System.Collections.Generic;

    using Turbino.Domain.Entities.Common;
    using Turbino.Domain.Enumerations;

    public class Tour : BaseModel
    {
        public Tour()
        {
            this.Reviews = new HashSet<Review>();
        }

        public string Name { get; set; }

        public decimal PricePerPerson { get; set; }

        public int RequiredAge { get; set; }

        public int Duration { get; set; }

        public string Location { get; set; }

        public string Dates { get; set; }

        public string Departure { get; set; }

        public string NextDeparture { get; set; }

        public string Accommodation { get; set; }

        public string Included { get; set; }

        public string NotIncluded { get; set; }

        public TourType TourType { get; set; }

        public string Description { get; set; }

        public string DestinationId { get; set; }

        public string ImgUrl { get; set; }

        public double Rating { get; set; }

        public Destination Destination { get; set; }

        public virtual ICollection<Review> Reviews { get; private set; }

        public virtual ICollection<TourImage> Galery { get; private set; }
    }
}
