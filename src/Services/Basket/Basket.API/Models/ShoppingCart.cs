using Marten.Schema;

namespace Basket.API.Models
{
    public class ShoppingCart
    {
        //[Identity]
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();

        //private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        //public IReadOnlyList<ShoppingCartItem> Items => _items.AsReadOnly();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        // Required for Mapping
        public ShoppingCart()
        {
        }
    }
}
