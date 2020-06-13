namespace Turbino.Application.Reviews.Queries.GetAllReviewsByTourId
{
    using System.Collections.Generic;

    public class GetAllReviewsByTourIdListViewModel
    {
        public GetAllReviewsByTourIdListViewModel()
        {
            this.Reviews = new List<GetAllReviewsByTourIdViewModel>();
        }

        public ICollection<GetAllReviewsByTourIdViewModel> Reviews { get; set; }
    }
}
