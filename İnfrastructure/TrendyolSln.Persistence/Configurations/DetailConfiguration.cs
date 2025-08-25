﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new();
            Detail detail1 = new()
            {
                Id=1,
                Title=faker.Lorem.Sentence(1),
                Description=faker.Lorem.Sentence(5),
                CategoryId = 1,
                IsDeleted = false
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                IsDeleted = true
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                IsDeleted = false
            };
            builder.HasData(detail1, detail2, detail3);
        }
    }
}
