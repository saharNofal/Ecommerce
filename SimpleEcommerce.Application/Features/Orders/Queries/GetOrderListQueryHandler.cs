using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;


namespace SimpleEcommerce.Application.Features.Orders.Queries
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<OrderVM>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var allCatagory = await _unitOfWork.OrderRepository.ListAllAsync();
            return _mapper.Map<List<OrderVM>>(allCatagory);
        }
    }

    public class GetOrderListQuery : IRequest<List<OrderVM>>
    {
    }
}
