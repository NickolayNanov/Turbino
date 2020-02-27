namespace Turbino.Domain.Entities
{
    using Turbino.Domain.Entities.Common;
    using Turbino.Domain.Enumerations;

    public class Review : BaseDeletableModel
    {
        public string Content { get; set; }

        public Rating Rating { get; set; }

        public string TourId { get; set; }
        public Tour Tour { get; set; }

        public string AuthorId { get; set; }
        public TurbinoUser Author { get; set; }
    }
}
