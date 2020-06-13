namespace Turbino.Application.Reservations.Queries.GetAllReservationsByUser
{
    using System.Collections.Generic;

    public class GetAllReservationsByUserList
    {
        public GetAllReservationsByUserList()
        {
            Reservations = new List<GetAllReservationsByUserViewModel>();
        }

        public virtual IList<GetAllReservationsByUserViewModel> Reservations { get; set; }
    }
}
