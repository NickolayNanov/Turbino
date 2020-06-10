using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Tours.Queries.SelectById;

namespace Turbino.WebApp.Views.Shared.Components
{
    public class TourTableViewComponent : ViewComponent
    {
        public TourTableViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(string tourId)
        { 
            return View(new TourViewModel() { Id = tourId });
        }
    }
}
