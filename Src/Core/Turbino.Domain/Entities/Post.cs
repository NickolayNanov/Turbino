namespace Turbino.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using Turbino.Domain.Entities.Common;


    public class Post : BaseDeletableModel
    {
        public Post()
        {
            this.PublishedOn = DateTime.Now;
        }

        public string Title { get; set; }

        public DateTime PublishedOn { get; set; }

        public virtual ICollection<Comment> Comments { get; private set; }
    }
}
