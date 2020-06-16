namespace Turbino.Application.Tours.Queries.GetAllToursFiltered
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Turbino.Domain.Common;
    using Turbino.Domain.Entities;
    using Turbino.Domain.Enumerations;
    using Turbino.Common.GlobalContants;
    using Turbino.Application.Common.Interfaces;
    using Turbino.Application.Tours.Queries.GetAllDestinations;

    using AutoMapper;
    using MediatR;

    public class GetAllToursWithFilterHandler : IRequestHandler<GetAllToursWithFilterQuery, GetAllToursWithFilterListViewModel>
    {
        private const string DefaultPrice = "$1000 - $2500";
        private const string DefaultMoth = "Any month";
        private const string DefaultTourType = "Tour Type";
        private const int PageSize = 12;
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;

        public GetAllToursWithFilterHandler(ITurbinoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GetAllToursWithFilterListViewModel> Handle(GetAllToursWithFilterQuery request, CancellationToken cancellationToken)
        {
            GetAllToursWithFilterListViewModel model = null;

            if (!IsValid(request))
            {
                model = new GetAllToursWithFilterListViewModel
                {
                    Tours = new List<GetAllToursListModel>(),
                    PageIndex = request.PageIndex ?? 0,
                    TourName = request.TourName,
                    DestinationName = request.DestinationName,
                    TourType = request.TourType,
                    Month = request.Month,
                    PriceStr = request.PriceStr,
                    SortOrder = request.SortOrder,
                    HaveMoreTours = false,
                    Errors = new string[] { ApplicationConstants.ConditionError }
                };
            }
            else
            {
                IQueryable<Tour> tours = context.Tours.Include(t => t.Destination).AsNoTracking();
                tours = FilterTours(request, tours);

                model = new GetAllToursWithFilterListViewModel
                {
                    Tours = await this.mapper.ProjectTo<GetAllToursListModel>(
                                                            PaginatedList<Tour>.Create(tours,
                                                                request.PageIndex ?? 1, PageSize)).ToListAsync(),
                    PageIndex = request.PageIndex ?? 0,
                    TourName = request.TourName,
                    DestinationName = request.DestinationName,
                    TourType = request.TourType,
                    Month = request.Month,
                    PriceStr = request.PriceStr,
                    SortOrder = request.SortOrder,
                    HaveMoreTours = tours.Skip((request.PageIndex == null ? 1 : request.PageIndex.Value) * PageSize)
                                         .Take((request.PageIndex == null ? 1 : request.PageIndex.Value + 1) * PageSize).Count() >= 0
                };
            }

            return model;
        }

        private static IQueryable<Tour> FilterTours(GetAllToursWithFilterQuery request, IQueryable<Tour> tours)
        {
            if (!string.IsNullOrEmpty(request.DestinationName))
            {
                tours = tours.Where(t => t.Destination.Name.ToLower().StartsWith(request.DestinationName.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.TourName))
            {
                tours = tours.Where(t => t.Name.ToLower().StartsWith(request.TourName.ToLower()));
            }

            if (request.TourType != DefaultTourType)
            {
                Enum.TryParse(request.TourType, out TourType type);
                tours = tours.Where(t => t.TourType == type);
            }

            if (request.Month != DefaultMoth)
            {
                tours = tours.Where(t => t.Dates.ToLower().Contains(request.Month.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.PriceStr))
            {
                string[] values = request.PriceStr.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                decimal minValue = decimal.Parse(values[0].Replace("$", ""));
                decimal maxValue = decimal.Parse(values[1].Replace("$", ""));
                tours = tours.Where(t => t.PricePerPerson >= minValue && t.PricePerPerson <= maxValue);
            }

            if (request.SortOrder != 0)
            {
                switch (request.SortOrder)
                {
                    case 1:
                        tours = tours.OrderBy(x => x.PricePerPerson);
                        break;
                    case 2:
                        tours = tours.OrderByDescending(x => x.PricePerPerson);
                        break;
                    case 3:
                        tours = tours.OrderBy(x => x.Dates);
                        break;
                    default: break;
                }
            }

            return tours;
        }

        private bool IsValid(GetAllToursWithFilterQuery request)
        {
            if ((request.PriceStr == DefaultPrice
                && string.IsNullOrEmpty(request.DestinationName)
                && request.Month == DefaultMoth
                && request.SortOrder == 0
                && request.TourType == DefaultTourType
                && string.IsNullOrEmpty(request.TourName)) ||
                (request.TourType == DefaultTourType && request.Month == DefaultMoth && string.IsNullOrEmpty(request.TourName)))
            {
                return false;
            }

            return true;
        }
    }
}
