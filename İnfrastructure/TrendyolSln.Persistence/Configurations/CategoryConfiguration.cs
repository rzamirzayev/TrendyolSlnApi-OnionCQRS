using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektrik",
                ParentId = 0,
                Priorty = 1,
                IsDeleted=false,
               
            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                ParentId = 0,
                Priorty = 2,
                IsDeleted = false,

            };

            Category parent1 = new()
            {
                Id = 3,
                Name = "Kompyuter",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
            };
            Category parent2 = new()
            {
                Id = 4,
                Name = "KISI",
                ParentId = 2,
                Priorty = 1,
                IsDeleted = false,

            };
            builder.HasData(category1,category2,parent1,parent2);


        }
    }
}
