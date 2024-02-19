using AutoMapper;
using Dashboard.Domain.Models;
using Domain.ViewModels;

namespace Dashboard.Domain.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}
