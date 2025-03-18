namespace BethanysPieShop.Mobile.Models;

public class ShoppingCartModel
{
    public long? Id { get; set; }

    public List<ShoppingCartItemModel>? Items { get; set; }
}