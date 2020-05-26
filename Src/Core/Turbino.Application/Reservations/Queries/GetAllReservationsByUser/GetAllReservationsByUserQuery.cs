using MediatR;

namespace Turbino.Application.Reservations.Queries.GetAllReservationsByUser
{
    public class GetAllReservationsByUserQuery : IRequest<GetAllReservationsByUserList>
    {
        public string Username { get; set; }
    }
}
