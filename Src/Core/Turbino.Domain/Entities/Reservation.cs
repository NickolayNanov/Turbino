namespace Turbino.Domain.Entities
{
    using System;

    using Turbino.Domain.Entities.Common;


    public class Reservation : BaseModel
    {
        public Reservation()
        {
            this.ReservedOn = DateTime.Now;
        }

        public string UserId { get; set; }

        public TurbinoUser User { get; set; }

        public string TourId { get; set; }

        public Tour Tour { get; set; }

        public DateTime ReservedOn { get; set; }
    }
}
