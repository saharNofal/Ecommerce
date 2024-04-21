using AutoMapper;
using SimpleEcommerce.Application.Features.Catagory.Commands.CreateCategory;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories;
using SimpleEcommerce.Application.Features.Notifications;
using SimpleEcommerce.Application.Features.Orders;
using SimpleEcommerce.Application.Features.Products;
using SimpleEcommerce.Application.Features.WishList;
using SimpleEcommerce.Domain.Entities;


namespace SimpleEcommerce.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CatagoryListVM>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<OrderItem, OrderItemVM>().ReverseMap();
            CreateMap<Wishlist, WishlistMV>().ReverseMap();
            CreateMap<NotificationSettings, NotificationVM>().ReverseMap();

        }
    }
}
