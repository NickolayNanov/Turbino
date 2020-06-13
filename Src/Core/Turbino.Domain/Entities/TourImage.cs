namespace Turbino.Domain.Entities
{
    using Turbino.Domain.Entities.Common;

    public class TourImage : BaseDeletableModel
    {
        public string Url { get; set; }

        public string TourId { get; set; }

        public Tour Tour { get; set; }
    }
}
