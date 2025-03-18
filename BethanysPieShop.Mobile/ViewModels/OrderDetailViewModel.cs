using System.Collections.ObjectModel;
using AutoMapper;
using BethanysPieShop.Mobile.Models;
using BethanysPieShop.Mobile.Services.Interfaces;
using BethanysPieShop.Mobile.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BethanysPieShop.Mobile.ViewModels;

[QueryProperty(nameof(Id), "OrderId")]
public partial class OrderDetailViewModel : ViewModelBase
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    [ObservableProperty] 
    private int _id;

    [ObservableProperty] 
    private DateTime _orderDate;

    [ObservableProperty] 
    private decimal _orderTotal;

    [ObservableProperty] 
    private ObservableCollection<OrderLineViewModel> _orderLines = new();

    [ObservableProperty] 
    private ShippingInformationViewModel? _shippingInformation;

    [ObservableProperty] 
    private long _trackAndTraceCode;

    [ObservableProperty] 
    private string? _deliveryAddress;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HideTrackingInformation))]
    private bool _showTrackingInformation;

    public bool HideTrackingInformation => !ShowTrackingInformation;

    public OrderDetailViewModel(
        INavigationService navigationService,
        IOrderService orderService,
        IMapper mapper)
        : base(navigationService)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    public override async Task InitializeAsync()
    {
        await Loading(GetData);
        ShowTrackingInformation = false;
    }

    private async Task GetData()
    {
        if (Id != 0)
        {
            var orderDetail = await _orderService.GetOrderById(Id);
            if (orderDetail == null)
            {
                GoBackCommand.Execute(null);
            }
            else
            {
                MapOrderDetailModelToViewModel(orderDetail);
            }
        }
    }

    private void MapOrderDetailModelToViewModel(OrderDetailModel orderDetail)
    {
        Id = orderDetail.Id;
        OrderDate = orderDetail.OrderDate;
        OrderTotal = orderDetail.OrderTotal;
        ShippingInformation = _mapper.Map<ShippingInformationViewModel>(orderDetail.ShippingInformation);
        OrderLines = MapOrderLinesModelToViewModel(orderDetail.OrderLines);
        TrackAndTraceCode = orderDetail.TrackAndTraceCode;
        DeliveryAddress =
            $"{ShippingInformation.FirstName} {ShippingInformation.LastName}, {ShippingInformation.AddressLine1}, {ShippingInformation.ZipCode} {ShippingInformation.City}";
    }

    private ObservableCollection<OrderLineViewModel> MapOrderLinesModelToViewModel(List<OrderLineModel> orderDetailOrderLines) 
        => _mapper.Map<ObservableCollection<OrderLineViewModel>>(orderDetailOrderLines);
}