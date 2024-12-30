using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    // 將ID 移至 BaseEntity
    public class Product: BaseEntity
    {       
        // 避免出現null 值，加上required 新增欄位
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string PictureUrl { get; set; }
        public  required string Type { get; set; }
        public  required string Brand { get; set; }
        public int QuantityInStock { get; set; }
    }
}
