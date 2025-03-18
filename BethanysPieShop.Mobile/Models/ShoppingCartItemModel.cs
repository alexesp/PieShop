namespace BethanysPieShop.Mobile.Models;

public class ShoppingCartItemModel
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int PieId { get; set; }

    public PieModel Pie { get; set; }
}