using AutoMapper;
using EventManager.Models;
using EventManager.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Extensions
{
    public class RequestsToDomainMappingProfile : Profile
    {
        public RequestsToDomainMappingProfile()
        {
            CreateMap<AttendRequest, Attend>();
        }
    }
}
