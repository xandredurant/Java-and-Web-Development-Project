using System.Text.Json;

namespace Java_and_Web_Development_Project.Services
{
    public class CartService
    {
        private List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void AddToCart(string itemName, decimal itemPrice, int quantity)
        {
            var existingItem = CartItems.FirstOrDefault(i => i.Name == itemName);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var newItem = new CartItem { Name = itemName, Price = itemPrice, Quantity = quantity };
                CartItems.Add(newItem);
            }
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems;
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }

        public class CartItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }

}
