using MediatR;


namespace SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<int>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
    }
}
