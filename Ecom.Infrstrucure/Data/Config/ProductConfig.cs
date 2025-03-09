using Ecom.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrstrucure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(33);
            builder.Property(x=> x.Id).IsRequired();
            builder.Property(x => x.NewPrice).IsRequired().HasColumnType("decimal(18,2)");//عشان يشيل خانتين بعد الفاصلة
            builder.HasData(new Product
            {
                Id = 1,
                Name = "Test",
                Dscription = "test",
                NewPrice = 20,
                CategoryId = 1,
                OldPrice = 10,
            });
        }
    }
}
