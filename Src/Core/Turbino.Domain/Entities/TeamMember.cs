using Turbino.Domain.Entities.Common;
using Turbino.Domain.Enumerations;

namespace Turbino.Domain.Entities
{
    public class TeamMember : BaseDeletableModel
    {
        public TeamMember() { }

        public TeamMember(string fullName, JobTitle jobTitle, string profilePicUrl)
        {
            this.FullName = fullName;
            this.JobTitle = JobTitle;
            this.ProfilePictureUrl = profilePicUrl;
        }

        public string FullName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public JobTitle JobTitle { get; set; }
    }
}
