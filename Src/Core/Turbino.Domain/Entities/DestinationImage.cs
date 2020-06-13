namespace Turbino.Domain.Entities
{
    using Turbino.Domain.Entities.Common;

    public class DestinationImage : BaseDeletableModel
    {
        public DestinationImage(string destinationId, string url)
        {
            this.DestinationId = destinationId;
            this.Url = url;
        }

        public string Url { get; set; }

        public string DestinationId { get; set; }

        public Destination Destination { get; set; }
    }
}
