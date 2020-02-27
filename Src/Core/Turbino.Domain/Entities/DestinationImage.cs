using Turbino.Domain.Entities.Common;

namespace Turbino.Domain.Entities
{
    public class DestinationImage : BaseDeletableModel
    {
        public string Url { get; set; }

        public string DestinationId { get; set; }

        public Destination Destination { get; set; }
    }
}
