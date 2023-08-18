using AutoMapper;
using ShoppingListDemo.Server.Models;
using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            CreateMap<ItemImage, ItemImageDto>().ReverseMap();

            CreateMap<ShoppingItemDto, ShoppingItem>()
                .ForMember(d => d.Images, o => o.MapFrom<ItemImageResolver>());

            CreateMap<ShoppingItem, ShoppingItemDto>()
                .ForMember(d => d.ImageFiles, o => o.MapFrom<ItemImageResolver>());
        }
    }
}
