using AutoMapper;
using Vidly___Tutorial_MVC5.Dtos;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(x => x.Id, opt => opt.Ignore()); ;

            // Movie
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(x => x.DateAdded, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());

            // Membership Type
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // Genre
            Mapper.CreateMap<Genre, GenreDto>();

        }
    }
}