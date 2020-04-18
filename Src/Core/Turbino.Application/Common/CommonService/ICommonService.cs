using System.Threading.Tasks;
using Turbino.Application.Tours.Commands.CreateTour;

namespace Turbino.Application.Common.CommonService
{
    public interface ICommonService
    {
        CreateTourCommand GetCommand();
    }
}
