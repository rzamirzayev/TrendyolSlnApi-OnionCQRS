using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker=new();
            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Price = faker.Finance.Amount(100, 1000),
                Discount = faker.Random.Decimal(0, 50),
                IsDeleted = false
            };
            Product produc2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                Price = faker.Finance.Amount(100, 1000),
                Discount = faker.Random.Decimal(0, 50),
                IsDeleted = false
            };
            builder.HasData(produc2, product1);
        }
    }
}
