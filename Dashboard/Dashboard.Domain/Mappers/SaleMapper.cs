using AutoMapper;
using Domain.Models.ViewModels;
using Dashboard.Domain.Models;

namespace Dashboard.Domain.Mappers
{
    public class SaleMapper : Profile
    {
        public SaleMapper()
        {
            CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src =>
                    src.SaleItems.Select(x => new ItemSale
                    {
                        Description = x.Description,
                        Quantity = x.Quantity,
                        UnityValue = x.UnityValue,
                        TotalValue = x.TotalValue
                    })
                ));

            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src =>
                    src.SaleItems.Select(x => new ItemSaleDto
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