namespace Turbino.Application.Tours.Queries.SelectById
{
    using System;
    using System.Collections.Generic;

    using Turbino.Application.Reviews.Queries.GetAllReviewsByTourId;
    public class TourViewModel
    {
        public string Id { get; set; }

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

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public double Rating { get; set; }

        public string Content { get; set; }

        public GetAllReviewsByTourIdListViewModel Reviews { get; set; }

        public string ReserverName { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public DateTime? DateOfLeaving { get; set; }

        public virtual IList<string> Included { get; set; }

        public virtual IList<string> NotIncluded { get; set; }
    }
}
