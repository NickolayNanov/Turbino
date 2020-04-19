﻿using MediatR;

namespace Turbino.Application.Destinations.Queries.GetDestinationById
{
    public class GetDestinationByIdQuery : IRequest<DestinationViewModel>
    {
        public GetDestinationByIdQuery()
        {

        }

        public GetDestinationByIdQuery(string id)
        {
            DestinationId = id;
        }
        
        public string DestinationId { get; set; }
    }
}
