using AutoMapper;
using BethanysPieShop.Mobile.Models;
using BethanysPieShop.Mobile.Repositories.Interfaces;

namespace BethanysPieShop.Mobile.Repositories;

public class OrderMockRepository : IOrderRepository
{
    private readonly IMapper _mapper;
    private static List<OrderDetailModel> Orders { get; set;  } = new();
    private readonly IPieRepository _pieRepository;

    public OrderMockRepository(IMapper mapper, IPieRepository pieRepository)
    {
        _mapper = mapper;
        _pieRepository = pieRepository;
    }
    
    public async Task<long> CreateOrder(OrderCreateModel orderCreateModel)
    {
        Random random = new Random();

        var orderLines = new List<OrderLineModel>();
        var i = 1;
        var pies = await _pieRepository.GetAllPies();
        foreach (var orderLine in orderCreateModel.OrderLines)
        {
            var pie = pies.Find(p => p.Id == orderLine.PieId);
            orderLines.Add(new OrderLineModel
            {
                Id = i,
                Quantity = orderLine.Quantity,
                TotalPrice = orderLine.TotalPrice,
                UnitPrice = orderLine.UnitPrice,
                Pie = new PieModel
                {
                    Id = orderLine.PieId,
                    CategoryId = 1,
                    Name = pie?.Name ?? "Mock Pie",
                    Price = orderLine.UnitPrice,
                    ImageThumbnailUrl = pie?.ImageThumbnailUrl,
                }
            });
            
            i++;
        }

        var orderDetails = new OrderDetailModel
        {
            Id = Orders.Count + 1,
            OrderDate = DateTime.UtcNow,
            OrderTotal = orderCreateModel.OrderLines.Sum(ol => ol.TotalPrice),
            ShippingInformation = _mapper.Map<ShippingInformationModel>(orderCreateModel.ShippingInformation),
            TrackAndTraceCode = random.NextInt64(99999),
            OrderLines = orderLines
        };
        
        Orders.Add(orderDetails);

        return (long)orderDetails.Id;
    }

    public Task<OrderDetailModel?> GetOrderById(int id)
    {
        var order = Orders.Find(o => o.Id == id);
        return Task.FromResult(order);
    }

    public Task<List<OrderModel>> GetOrderHistory()
    {
        var orders = Orders.Select(o => new OrderModel
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            OrderTotal = o.OrderTotal
        }).ToList();

        return Task.FromResult(orders);
    }
}