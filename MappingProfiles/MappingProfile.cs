using AutoMapper;
using SkyFlix.Dto;
using SkyFlix.Models;


namespace SkyFlix.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}

