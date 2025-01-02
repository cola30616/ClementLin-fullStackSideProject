using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using sp_skishop.RequestHelpers;

namespace sp_skishop.Controllers
{   
    public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
    {      
        // ActioResult 支援generic 
        [HttpGet] // 全部的商品
        // 因為是用物件傳遞參數，記得要補上[FromQuery]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProductSpecification(specParams);

            return await CreatePagedResult(repo, spec, specParams.PageIndex, specParams.PageSize);
        }

        [HttpGet("{id:int}")] // api/products/2 單一商品
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);

            if (await repo.SaveAllAsync())
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
            repo.Update(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }

            
            return BadRequest("Problem updating the product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            repo.Remove(product);
            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }

           
            return BadRequest("Problem deleting the product");
        }
        // api/product/brands  
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {           
            var spec = new BrandListSpecification(); 
            return Ok(await repo.ListAsync(spec));
        }
        //{{url}}/api/products/types  會根據目前的query param ，發送請求
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {           
            var spec = new TypeListSpecification();
            return Ok(await repo.ListAsync(spec));
        }
        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
