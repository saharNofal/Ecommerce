using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Features.Orders;
using SimpleEcommerce.Domain.Entities;


namespace SimpleEcommerce.Application.Features.Catagory.Commands.CreateOrder
{
    public class CreateOrderQueryHandler : IRequestHandler<OrderVM, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

           _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<int> Handle(OrderVM request, CancellationToken cancellationToken)
        {
           var @Order= _mapper.Map<Order>(request);
            var validator= new CreateOrderCommandValidator();
            var validationResults=   await validator.ValidateAsync(request);
           if (validationResults.Errors.Count > 0)
               throw new Exceptions.ValidationException(validationResults);
            var orderItemsVm = request.OrderItems.ToList();

            var orderItemValidator = new CreateOrderItemValidator();
            var validateResults = await orderItemValidator.ValidateAsync(orderItemsVm);
            if (validationResults != null && validationResults.Errors.Count > 0)
                throw new Exceptions.ValidationException(validateResults);


            var orderItems = _mapper.Map<List<OrderItem>>(orderItemsVm);
            if (@Order.OrderId > 0 )
            {
                await _unitOfWork.OrderRepository.UpdateOrderAsync(@Order);
                
            }
            else
            {
                @Order = await _unitOfWork.OrderRepository.AddAsync(@Order);
                
            }
            await _unitOfWork.CommitAsync();
            return Order.OrderId;
        }
    }
}
