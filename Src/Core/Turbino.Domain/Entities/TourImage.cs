using Turbino.Domain.Entities.Common;

namespace Turbino.Domain.Entities
{
    public class TourImage : BaseDeletableModel
    {
        public string Url { get; set; }

        public string TourId { get; set; }

        public Tour Tour { get; set; }
    }
}
