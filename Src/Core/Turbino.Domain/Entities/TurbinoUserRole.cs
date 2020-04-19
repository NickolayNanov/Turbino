namespace Turbino.Domain.Entities
{
    public class TurbinoUserRole
    {
        public string UserId { get; set; }
        public TurbinoUser User { get; set; }

        public string RoleId { get; set; }
        public TurbinoRole Role { get; set; }
    }
}
