using Turbino.Domain.Entities.Common;

namespace Turbino.Domain.Entities
{
    public class Comment : BaseDeletableModel
    {
        public string Content { get; set; }

        public string PostId { get; set; }

        public Post Post { get; set; }

        //public string AuthorId { get; set; }
        //
        //public TurbinoUser Author { get; set; }
    }
}