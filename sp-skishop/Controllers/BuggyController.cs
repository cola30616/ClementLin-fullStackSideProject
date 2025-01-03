using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using sp_skishop.DTOs;

namespace sp_skishop.Controllers
{
    // 錯誤測試用控制器
    public class BuggyController: BaseApiController
    {
        // 檢查是否授權
        [HttpGet("unauthorized")]
        public IActionResult GetAuthorized()
        {
            return Unauthorized();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest("Not a good request");
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("This is a test exception");
        }

        [HttpPost("validationerror")]
        public IActionResult GetValidationError(CreateProductDto product)
        {
            return Ok();
        }
    }
}
