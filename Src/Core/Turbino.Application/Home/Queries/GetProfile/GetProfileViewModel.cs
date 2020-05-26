using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Home.GetProfile
{
    public class GetProfileViewModel : IHaveCustomMapping
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [RegularExpression("^((0877|0887|089)([0-9]{6})){1,10}$")]
        public string PhoneNumber { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<TurbinoUser, GetProfileViewModel>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.MiddleName, y => y.MapFrom(z => z.MiddleName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber));
        }
    }
}
