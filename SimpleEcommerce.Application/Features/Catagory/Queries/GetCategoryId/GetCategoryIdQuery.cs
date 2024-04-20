using MediatR;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories;


namespace SimpleEcommerce.Application.Features.Catagory.Queries.GetCategoryId
{
    public class GetCategoryIdQuery : IRequest<CatagoryListVM>
    {
        public int CatagoryId { get; set; }

        public GetCategoryIdQuery(int catagoryId)
        {
            CatagoryId = catagoryId;
        }
    }
}
