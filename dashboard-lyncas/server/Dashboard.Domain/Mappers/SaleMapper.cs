using AutoMapper;
using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;
using Dashboard.Domain.Dtos;

namespace Dashboard.Domain.Mappers
{
    public class SaleMapper : Profile
    {
        public SaleMapper()
        {
            CreateMap<Sale, SaleViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ReverseMap();

            CreateMap<Sale, SaleWithItemsViewModel>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems))
                .ReverseMap();

            CreateMap<ItemSale, ItemSaleViewModel>().ReverseMap();

            CreateMap<ItemSaleDto, ItemSale>();

            CreateMap<SaleDto, Sale>();
        }
    }
}