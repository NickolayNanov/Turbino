using System;
using System.Linq;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Application.Tours.Commands.CreateTour;

namespace Turbino.Application.Common.CommonService
{
    public class CommonService : ICommonService
    {
        private readonly ITurbinoDbContext context;

        public CommonService(ITurbinoDbContext context)
        {
            this.context = context;
        }

        public CreateTourCommand GetCommand()
        {
            CreateTourCommand command = new CreateTourCommand()
            {
                IncludeOptions = Enum.GetNames(typeof(IncludedOptions)).Select(x => x.Replace("_", " ")),
                NotIncludeOption = Enum.GetNames(typeof(NotIncludedOptions)).Select(x => x.Replace("_", " ")),
                Destinations = context.Destinations.Select(x => new DestinationDto() { Id = x.Id, Name = x.Name}).AsEnumerable()
            };

            return command;
        }
    }
}
