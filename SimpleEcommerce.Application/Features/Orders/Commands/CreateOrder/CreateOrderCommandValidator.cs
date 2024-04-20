using FluentValidation;
using SimpleEcommerce.Application.Features.Orders;


namespace SimpleEcommerce.Application.Features.Catagory.Commands.CreateOrder
{
    public class CreateOrderCommandValidator:AbstractValidator<OrderVM>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x).Must(items => items.OrderItems.Count > 0).WithMessage("The order must contain at least one item.");
        }
    }
    public class CreateOrderItemValidator : AbstractValidator<List<OrderItemVM>>
    {
        public CreateOrderItemValidator()
        {
            RuleForEach(x => x).SetValidator(new OrderItemValidator());


        }
    }
    public class OrderItemValidator : AbstractValidator<OrderItemVM>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            // Add more validation rules for other properties of OrderItemVM as needed
        }
    }
}
