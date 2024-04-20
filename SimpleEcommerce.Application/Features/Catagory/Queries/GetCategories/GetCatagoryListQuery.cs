using MediatR;


namespace SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories
{
    public class GetCatagoryListQuery: IRequest<List<CatagoryListVM>>
    {
    }
}
