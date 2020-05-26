using AutoMapper;
using System;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Reservations.Queries.GetAllReservationsByUser
{
    public class GetAllReservationsByUserViewModel : IHaveCustomMapping
    {
        public string DestinationName { get; set; }

        public string TourName { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime LeavingDate { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Reservation, GetAllReservationsByUserViewModel>()
                .ForMember(x => x.TourName, y => y.MapFrom(z => z.Tour.Name))
                .ForMember(x => x.DestinationName, y => y.MapFrom(z => z.Tour.Destination.Name))
                .ForMember(x => x.ArrivalDate, y => y.MapFrom(z => z.DepartureDate))
                .ForMember(x => x.LeavingDate, y => y.MapFrom(z => z.DateOfLeaving));
        }
    }
}
