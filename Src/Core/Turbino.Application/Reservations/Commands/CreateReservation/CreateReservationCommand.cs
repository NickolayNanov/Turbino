namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    using System;
    using MediatR;

    public class CreateReservationCommand : IRequest<string[]>
    {
        public CreateReservationCommand() { }

        public CreateReservationCommand(string username, string tourId, string reserverName, DateTime arrivalDate, DateTime DateOfLeaving)
        {
            this.UserName = username;
            this.TourId = tourId;
            this.ReserverName = reserverName;
            this.ArrivalDate = arrivalDate;
            this.DateOfLeaving = DateOfLeaving;
        }

        public string UserName { get; set; }

        public string TourId { get; set; }

        public string ReserverName { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public DateTime? DateOfLeaving { get; set; }
    }
}
