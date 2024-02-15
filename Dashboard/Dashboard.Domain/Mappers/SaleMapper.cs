using AutoMapper;
using Domain.Models.ViewModels;
using Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Domain.Mappers
{
    public class SaleMapper : Profile
    {
        public SaleMapper()
        {
            CreateMap<SaleViewModel, Sale>();
            CreateMap<SaleWithCustomerViewModel, Sale>();
        }
    }
}


/*
 * CreateMap<CreateSaleViewModel, Sale>()
    .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
    src.Items.Select(x => new Item
    {
        ItemDescription = x.ItemDescription,
        UnitaryValue = x.UnitaryValue,
        Quantity = x.Quantity,
        Amount = x.Amount
    })
    ));
*/