using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(pc => pc.Product)
                   .WithMany(p => p.ProductCategories)
                   .HasForeignKey(pc => pc.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(pc => pc.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
