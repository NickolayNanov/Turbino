using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Turbino.Application.Reservations.Queries.GetAllReservationsByUser
{
    public class GetAllReservationsByUserList
    {
        public GetAllReservationsByUserList()
        {
            Reservations = new List<GetAllReservationsByUserViewModel>();
        }

        public IList<GetAllReservationsByUserViewModel> Reservations { get; set; }
    }
}
