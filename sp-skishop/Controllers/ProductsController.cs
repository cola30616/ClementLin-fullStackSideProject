using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sp_skishop.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductRepository repo) : ControllerBase
    {      
        // ActioResult 支援generic 
        [HttpGet] // 全部的商品
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            return Ok(await repo.GetProductsAsync(brand, type, sort));
        }

        [HttpGet("{id:int}")] // api/products/2 單一商品
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.AddProduct(product);

            if (await repo.SaveChangeAsync())
            {
                return CreatedAtAction("Get Product", new {id = product.Id}, product);
            }
            return BadRequest("Problem creating the product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id)) return BadRequest("cannot update this product");
            // 通知EF 當前追蹤的資料，之後才save change async ，確保資料正常~
            repo.UpdateProduct(product);

            if (await repo.SaveChangeAsync())
            {
                return NoContent();
            }

            
            return BadRequest("Problem updating the product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            repo.DeleteProduct(product);
            if (await repo.SaveChangeAsync())
            {
                return NoContent();
            }

           
            return BadRequest("Problem deleting the product");
        }
        // api/product/brands  
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            return Ok(await repo.GetBrandsAsync());
        }
        //{{url}}/api/products/types  會根據目前的query param ，發送請求
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            return Ok(await repo.GetTypesAsync());
        }
        private bool ProductExists(int id)
        {
            return repo.ProductExists(id);
        }
    }
}
