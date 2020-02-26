namespace Turbino.Domain.Entities
{
    using System.Collections.Generic;

    using Turbino.Domain.Entities.Common;

    public class Destination : BaseModel
    {
        public Destination()
        {
            this.DestionationUsers = new HashSet<UserDestination>();
            this.Tours = new HashSet<Tour>();
        }

        public string Name { get; set; }

        public int TimesVisited { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public string LanguageSpoken { get; set; }

        public int SquareArea { get; set; }

        public virtual ICollection<Tour> Tours { get; private set; }

        public virtual ICollection<UserDestination> DestionationUsers { get; private set; }

        public void Visit()
        {
            this.TimesVisited++;
        }
    }
}
