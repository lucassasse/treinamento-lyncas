using AutoMapper;
using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Domain.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
