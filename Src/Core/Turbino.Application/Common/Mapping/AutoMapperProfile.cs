using AutoMapper;

namespace Turbino.Application.Common.Mapping
{
    using System.Reflection;
    using System.Collections.Generic;

    using Turbino.Application.Interfaces.Mapping;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.LoadStandardMappings();
            this.LoadCustomMappings();
            this.LoadConverters();
        }

        private void LoadConverters()
        {
        }

        private void LoadStandardMappings()
        {
            IList<Map> mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadCustomMappings()
        {
            IList<IHaveCustomMapping> mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
