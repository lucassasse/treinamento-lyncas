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
            CreateMap<Sale, SaleViewModel>();

            CreateMap<Sale, SaleWithItemsViewModel>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src =>
                    src.SaleItems.Select(x => new ItemSaleViewModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Quantity = x.Quantity,
                        UnityValue = x.UnityValue,
                        TotalValue = x.TotalValue
                    })
                ));

            CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src =>
                    src.SaleItems.Select(x => new ItemSale
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Quantity = x.Quantity,
                        UnityValue = x.UnityValue,
                        TotalValue = x.TotalValue
                    })
                ));
        }
    }
}