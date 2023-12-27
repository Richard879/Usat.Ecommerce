using AutoMapper;
using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Application.DTO;

namespace Usat.Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //Para hacer el mapeo entre dto y entidades / viceversa
            //Esta será usado por la capa de aplicación
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName)).ReverseMap();
        }
    }
}
