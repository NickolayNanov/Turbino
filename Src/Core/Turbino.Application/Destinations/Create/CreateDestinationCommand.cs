﻿using MediatR;

namespace Turbino.Application.Destinations.Create
{
    public class CreateDestinationCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SpokenLanguage { get; set; }

        public string Visa { get; set; }

        public string Currency { get; set; }

        public int SquareArea { get; set; }
    }
}
