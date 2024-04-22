using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using SimpleEcommerce.Application.Features.Orders;
using SimpleEcommerce.Application.Features.Orders.Queries;
using SimpleEcommerce.Application.Features.Products.Queries;
using SimpleEcommerce.Persistence;

namespace SimpleEcommerce.Admin.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private readonly IMediator _mediator;
        UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<NotificationHub> _hubContext;

        public OrderController(IMediator mediator , UserManager<ApplicationUser> userManager, IHubContext<NotificationHub> hubContext)
        {
            _mediator = mediator;
           _userManager= userManager;
            _hubContext= hubContext;
        }

        // GET
        public async Task<IActionResult> Index(DateTime? OrderDate)
        {
            
            var OrderList = await _mediator.Send(new GetOrderListQuery());
            return View(OrderList);
        }

     

        // GET: /Order/Create
        public async Task<IActionResult> Add(int orderId)
        {
            var order = new OrderVM();
            ViewBag.Products = await _mediator.Send(new GetProductByCategoryQuery(0));
            if (orderId > 0)
            {
                order = await _mediator.Send(new GetOrderByIdQuery(orderId));
                return View(order);
            }
            return View();
        }

        // POST: /Order/Create
        [HttpPost]
        public async Task<ActionResult> Add(OrderVM order)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            ViewBag.Products = await _mediator.Send(new GetProductByCategoryQuery(0));

            order.UserId = user.Id;
            if (ModelState.IsValid)
            {             
                 await _mediator.Send(order);
                if(order.OrderId== 0)
                {

                    await _hubContext.Clients.Group("Admins").SendAsync("NewOrder", $"{user.UserName} Create a new order number {order.OrderId}.");

                    
                }
                return RedirectToAction("Index", "Order");

            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Remove(int orderId, int itemId)
        {
           
            return RedirectToAction("ViewOrder", new { id = orderId });
        }
    }

}
