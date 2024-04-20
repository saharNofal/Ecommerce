using MediatR;


namespace SimpleEcommerce.Application.Features.Products.Queries
{
    public class GetProductByCategoryQuery : IRequest<List<ProductVM>>
    {
        public int? CategoryId { get; set; }

        public GetProductByCategoryQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
