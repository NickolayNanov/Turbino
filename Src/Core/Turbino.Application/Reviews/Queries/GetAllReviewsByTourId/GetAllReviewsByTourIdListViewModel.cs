using System.Collections.Generic;

namespace Turbino.Application.Reviews.Queries.GetAllReviewsByTourId
{
    public class GetAllReviewsByTourIdListViewModel
    {
        public GetAllReviewsByTourIdListViewModel()
        {
            this.Reviews = new List<GetAllReviewsByTourIdViewModel>();
        }

        public ICollection<GetAllReviewsByTourIdViewModel> Reviews { get; set; }
    }
}
