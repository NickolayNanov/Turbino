﻿namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    using System.Collections.Generic;

    public class DestinationsListViewModel
    {
        public DestinationsListViewModel()
        {
            this.PageIndex = 1;
            Errors = new string[0];
        }

        public string[] Errors { get; set; }

        public int? PageIndex { get; set; } = 1;

        public string SearchQuery { get; set; }

        public string PriceRange { get; set; }

        public bool HaveMoreDestinations { get; set; }

        public virtual IList<DestinationsAllListModel> Destinations { get; set; }
    }
}
