using System.Text.Json;

namespace Java_and_Web_Development_Project.Services
{
    public class CartService
    {
        // List to store cart items
        private List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Adds an item to the cart or updates the quantity if the item already exists
        public void AddToCart(string itemName, decimal itemPrice, int quantity)
        {
            // Check if the item already exists in the cart
            var existingItem = CartItems.FirstOrDefault(i => i.Name == itemName);
            if (existingItem != null)
            {
                // Update quantity if item exists
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new item to the cart
                var newItem = new CartItem { Name = itemName, Price = itemPrice, Quantity = quantity };
                CartItems.Add(newItem);
            }
        }

        // Returns the list of items in the cart
        public List<CartItem> GetCartItems()
        {
            return CartItems;
        }

        // Clears all items from the cart
        public void ClearCart()
        {
            CartItems.Clear();
        }

        // Represents an item in the cart
        public class CartItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }
}
