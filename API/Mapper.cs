using AutoMapper;
using DTO;
using Entities;

namespace API
{
    public class Mapper :Profile
    {

        public Mapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Order, OrderReturnDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName,
                 opts => opts.MapFrom(src => src.Category.CategoryName)).ReverseMap();



        }






    }
}
