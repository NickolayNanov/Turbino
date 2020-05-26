using MediatR;
using System;

namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest
    {
        public string UserName { get; set; }

        public string TourId { get; set; }

        public string Name { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime DateOfLeaving { get; set; }
    }
}
