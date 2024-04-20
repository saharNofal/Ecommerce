using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories;

namespace SimpleEcommerce.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categoryList = await _mediator.Send(new GetCatagoryListQuery());
            return View(categoryList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommand category)
        {
            if (ModelState.IsValid)
            {
                var proudect = await _mediator.Send(category);
                return RedirectToAction("Index", "Categories");

            }
            return View(category);
        }
    }
}
