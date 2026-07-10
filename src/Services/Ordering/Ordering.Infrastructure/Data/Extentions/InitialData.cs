namespace Ordering.Infrastructure.Data.Extentions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("11111111-1111-1111-1111-111111111111")),"John Doe", "john.doe@example.com"),
                Customer.Create(CustomerId.Of(new Guid("22222222-2222-2222-2222-222222222222")),"Jane Smith", "jane.smith@example.com"),
                Customer.Create(CustomerId.Of(new Guid("33333333-3333-3333-3333-333333333333")),"Bob Johnson", "bob.johnson@example.com"),
                Customer.Create(CustomerId.Of(new Guid("44444444-4444-4444-4444-444444444444")),"Alice Williams", "alice.williams@example.com"),
                Customer.Create(CustomerId.Of(new Guid("55555555-5555-5555-5555-555555555555")),"Charlie Brown", "charlie.brown@example.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")), "iPhone 15", 599.99m),
                Product.Create(ProductId.Of(new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")), "Samsung Galaxy S23", 159.99m),
                Product.Create(ProductId.Of(new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc")), "Google Pixel 7", 549.49m),
                Product.Create(ProductId.Of(new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd")), "OnePlus 11", 415.75m),
                Product.Create(ProductId.Of(new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee")), "Xiaomi 13", 257.99m)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("John", "Doe", "john.doe@example.com", "123 Main St", "US", "New York", "10001");
                var address2 = Address.Of("Jane", "Smith", "jane.smith@example.com", "456 Oak Ave", "US", "Los Angeles", "90210");

                var payment1 = Payment.Of("Credit Card", "1234 5678 9012 3456", "12/25", "123", 1);
                var payment2 = Payment.Of("PayPal", "jane.smith@example.com", "12/25", "123", 2);


                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("11111111-1111-1111-1111-111111111111")),
                    OrderName.Of("ORD_1"),
                    address1,
                    address2,
                    payment1);
                order1.Add(ProductId.Of(new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")), 1, 599.99m);
                order1.Add(ProductId.Of(new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")), 2, 159.99m);

                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("22222222-2222-2222-2222-222222222222")),
                    OrderName.Of("ORD_1"),
                    address2,
                    address1,
                    payment2);
                order2.Add(ProductId.Of(new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc")), 1, 549.49m);
                order2.Add(ProductId.Of(new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd")), 1, 415.75m);

                return new[] { order1, order2 };
            }
        }
    }
}
