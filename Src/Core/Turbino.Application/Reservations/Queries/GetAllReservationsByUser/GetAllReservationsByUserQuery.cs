namespace Turbino.Application.Reservations.Queries.GetAllReservationsByUser
{
    using MediatR;

    public class GetAllReservationsByUserQuery : IRequest<GetAllReservationsByUserList>
    {
        public string Username { get; set; }
    }
}
