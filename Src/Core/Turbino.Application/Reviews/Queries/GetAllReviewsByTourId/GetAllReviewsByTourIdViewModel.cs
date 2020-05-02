using AutoMapper;
using System;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Reviews.Queries.GetAllReviewsByTourId
{
    public class GetAllReviewsByTourIdViewModel : IHaveCustomMapping
    {
        public string AuthorName { get; set; }

        public int Rating { get; set; }

        public string TimeAgo { get; set; }

        public string Content { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Review, GetAllReviewsByTourIdViewModel>()
                .ForPath(x => x.TimeAgo, y => y.MapFrom(z => Calculate(z.CreatedOn)))
                .ForMember(x => x.Rating, y => y.MapFrom(z => (int)z.Rating))
                .ForMember(x => x.AuthorName, y => y.MapFrom(z => $"{z.Author.FirstName} {z.Author.LastName}"));
        }

        private string Calculate(DateTime date)
        {
            string str = "{0} ago";
            string placeHolder = string.Empty;

            if(date.Hour > 24)
            {
                placeHolder = $"{date.Day} days";
            }
            else
            {
                placeHolder = $"{date.Hour} hours";
            }

            return string.Format(str, placeHolder);
        }
    }
}
