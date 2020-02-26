namespace Turbino.Domain.Entities
{
    public class UserDestination
    {
        public string UserId { get; set; }
        public TurbinoUser User { get; set; }

        public string DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}
