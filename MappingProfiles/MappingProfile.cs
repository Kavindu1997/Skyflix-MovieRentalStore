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
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>()
                   .ForMember(c => c.Id, opt => opt.Ignore());


            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();
        }
    }
}

