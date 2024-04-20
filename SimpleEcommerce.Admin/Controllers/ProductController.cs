using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories;
using SimpleEcommerce.Application.Features.Products;
using SimpleEcommerce.Application.Features.Products.Commands;
using SimpleEcommerce.Application.Features.Products.Queries;
using SimpleEcommerce.Application.Features.WishList;
using SimpleEcommerce.Persistence;

namespace SimpleEcommerce.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHubContext<NotificationHub> _hubContext;
        UserManager<ApplicationUser> _userManager;

        public ProductController(IMediator mediator, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, IHubContext<NotificationHub> hubContext)
        {
            _mediator = mediator;
            _webHostEnvironment= webHostEnvironment;
            _hubContext= hubContext;
            _userManager= userManager;
        }

 
        public async Task<IActionResult> Index(int? categoryId)
        {
            ViewBag.Categories = await _mediator.Send(new GetCatagoryListQuery());
            var categoryList = await _mediator.Send(new GetProductByCategoryQuery(categoryId));
            return View(categoryList);
        }

        public async Task<IActionResult> Add(int? proudectId)
        {
            var categoryList = await _mediator.Send(new GetCatagoryListQuery());
            var product = new ProductVM();


            if (proudectId != null)
            {
                 product = await _mediator.Send(new GetProductByIdQuery((int)proudectId));
            }              
            ViewBag.Categories = new SelectList(categoryList, "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductVM product)
        {
            var categoryList = await _mediator.Send(new GetCatagoryListQuery());
            ViewBag.Categories = new SelectList(categoryList, "CategoryId", "Name");


            if (ModelState.IsValid)
            {


                string uniqueFileName = null;
                if (product.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    product.ImagePath= "/images/"+ uniqueFileName;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }
                }
                var proudect = await _mediator.Send(product);
                
               await _hubContext.Clients.All.SendAsync("NewProductAdded", product.Name);


                return RedirectToAction("Index", "Product");

            }
            return View(product);
        }
       
        public async Task<IActionResult> Delete(int id)
        {           
                await _mediator.Send(new DeleteProductCommand(id));       
                return RedirectToAction("Index", "Product");
           
        }
        public async Task<IActionResult> AddToWishList(int ProductId)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _mediator.Send(new WishlistMV() { ProductId=ProductId, UserId= user.Id});
            return RedirectToAction("WishList", "Product");

        }
        public async Task<IActionResult> WishList()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
           
            var wishlistList = await _mediator.Send( new GetProductByUserIdQuery(user.Id));
            return View(wishlistList);
        }
    }


}
