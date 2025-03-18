using AutoMapper;
using BethanysPieShop.Mobile.Models;
using BethanysPieShop.Mobile.ViewModels;

namespace BethanysPieShop.Mobile.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderLineViewModel, OrderLineModel>().ReverseMap();
    }
}