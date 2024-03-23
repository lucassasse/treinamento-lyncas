using AutoMapper;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Domain.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
