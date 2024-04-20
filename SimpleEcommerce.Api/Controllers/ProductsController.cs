using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Application.Features.Products;
using SimpleEcommerce.Application.Features.Products.Queries;


namespace SimpleEcommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetProductByCategory", Name = "GetProductByCategory")]
        public async Task<IActionResult> GetProductByCategory(int? categoryId)
        {
            var productList = await _mediator.Send(new GetProductByCategoryQuery(categoryId));
            return Ok(productList);
        }

        [HttpGet("GetProductById", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int proudectId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(proudectId));
            return Ok(product);
        }

        [HttpPost("AddEditProduct")]
        public async Task<IActionResult> AddEditProduct([FromBody] ProductVM product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            try
            {
                var productId = await _mediator.Send(product);
                return CreatedAtRoute("GetProductById", new { productId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();

        }


        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage()
        {
            var file = Request.Form.Files[0];
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            var uploadsPath = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var filePath = Path.Combine(uploadsPath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
          var ImagePath = "/uploads/" + uniqueFileName;
            return Ok(new { Path = ImagePath });
        }

    }
}
