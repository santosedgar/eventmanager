using AutoMapper;
using EventManager.Models;
using EventManager.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Extensions
{
    public class DomainToResponseMappingProfile: Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Event, EventResponse>();
        }
    }
}
