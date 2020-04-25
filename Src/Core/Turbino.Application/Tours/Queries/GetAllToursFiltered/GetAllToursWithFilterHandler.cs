using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Application.Tours.Queries.GetAllDestinations;
using Turbino.Domain.Common;
using Turbino.Domain.Entities;
using Turbino.Domain.Enumerations;

namespace Turbino.Application.Tours.Queries.GetAllToursFiltered
{
    public class GetAllToursWithFilterHandler : IRequestHandler<GetAllToursWithFilterQuery, GetAllToursWithFilterListViewModel>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;

        public GetAllToursWithFilterHandler(ITurbinoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GetAllToursWithFilterListViewModel> Handle(GetAllToursWithFilterQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Tour> tours = context.Tours.Include(t => t.Destination).AsNoTracking();

            if (!string.IsNullOrEmpty(request.DestinationName))
            {
                tours = tours.Where(t => t.Destination.Name.ToLower().StartsWith(request.DestinationName.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.TourName))
            {
                tours = tours.Where(t => t.Name.ToLower().StartsWith(request.TourName.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.TourType))
            {
                TourType type = Enum.Parse<TourType>(request.TourType);
                tours = tours.Where(t => t.TourType == type);
            }
            if (!string.IsNullOrEmpty(request.Month))
            {
                tours = tours.Where(t => t.Dates.ToLower().Contains(request.Month.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.PriceStr))
            {
                //"$1000 - $2500"
                string[] values = request.PriceStr.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                decimal minValue = decimal.Parse(values[0].Replace("$", ""));
                decimal maxValue = decimal.Parse(values[1].Replace("$", ""));
                tours = tours.Where(t => t.PricePerPerson > minValue && t.PricePerPerson < maxValue);
            }
            if(request.SortOrder != 0)
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
            return new GetAllToursWithFilterListViewModel
            {
                Tours = await this.mapper.ProjectTo<GetAllToursListModel>(
                                                        PaginatedList<Tour>.Create(tours,
                                                            request.PageIndex ?? 1, 12)).ToListAsync(),
                PageIndex = request.PageIndex ?? 0,
                TourName = request.TourName,
                DestinationName = request.DestinationName,
                TourType = request.TourType,
                Month = request.Month,
                PriceStr = request.PriceStr,
                SortOrder = request.SortOrder,
                HaveMoreTours = context.Tours.Where(t => t.Name.StartsWith(request.TourName)).Count() > (request.PageIndex ?? 1) * 12
            };
        }
    }
}
