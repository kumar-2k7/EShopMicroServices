using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            // Marten UPSERT will create for existing records
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product
            {
                Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"),
                Name = "IPhone X",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string> { "Mobile", "Apple" }
            },
            new Product
            {
                Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0852"),
                Name = "Samsung 10",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-2.png",
                Price = 840.00M,
                Category = new List<string> { "Mobile", "Samsung" }
            },
            new Product
            {
                Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0853"),
                Name = "Huawei Plus",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-3.png",
                Price = 650.00M,
                Category = new List<string> { "Mobile", "Huawei" }
            },
            new Product
            {
                Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0854"),
                Name = "Xiaomi Mi 9",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-4.png",
                Price = 470.00M,
                Category = new List<string> { "Mobile", "Xiaomi" }
            },
            new Product
            {
                Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0855"),
                Name = "HTC U11+ Plus",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-5.png",
                Price = 380.00M,
                Category = new List<string> { "Mobile", "HTC" }
            },
            new Product
            {
                Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0856"),
                Name = "LG G7 ThinQ",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-6.png",
                Price = 240.00M,
                Category = new List<string> { "Mobile", "LG" }
            }
        };
    }
}
