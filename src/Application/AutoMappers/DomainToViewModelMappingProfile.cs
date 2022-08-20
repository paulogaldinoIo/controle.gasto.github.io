using Application.ModelViews.Persona.Customers;
using AutoMapper;
using Domain.Models.Persona.Users;

namespace Application.AutoMappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }

    }
}
