using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    // 這個class用於明確設定 資料表欄位的資料型別細節
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // 設定資料細節
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");          
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
