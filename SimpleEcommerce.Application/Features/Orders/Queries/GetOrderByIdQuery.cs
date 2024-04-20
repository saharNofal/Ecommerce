using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;


namespace SimpleEcommerce.Application.Features.Orders.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderVM>
        {

        
        private readonly IUnitOfWork _unitOfWork;


        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_orderRepository = orderRepository;
            //_orderItemRepository = orderItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderVM> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.FindOrderById(request.OrderId);
         
            var orderViewModel = _mapper.Map<OrderVM>(order);
            return orderViewModel;
        }
    }

    public class GetOrderByIdQuery : IRequest<OrderVM>
    {       
         public int OrderId { get; set; }
        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}
