using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategoryId;

namespace SimpleEcommerce.Api.Controllers
{
    //[Authorize]
    //[ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all",Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CatagoryListVM>>> Get()
        {
            var categoryList = await _mediator.Send(new GetCatagoryListQuery());
            return Ok(categoryList);
        }
        [HttpPost("Add",Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCategoryCommand>> Add([FromBody] CreateCategoryCommand category)
        {
            if (ModelState.IsValid)
            {
                var categoryId = await _mediator.Send(category);
                return Ok(categoryId);
            }
            return Ok(category);
        }

        [HttpGet("GetCategoryById", Name = "GetCategoryById")]

        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var product = await _mediator.Send(new GetCategoryIdQuery(categoryId));
            return Ok(product);
        }
    }
}