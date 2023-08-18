using AutoMapper;
using ShoppingListDemo.Server.Models;
using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Server.Mapper
{
    public class ItemImageResolver : IValueResolver<ShoppingItemDto, ShoppingItem, List<ItemImage>>, IValueResolver<ShoppingItem, ShoppingItemDto, List<ImageFile>>
    {
        public List<ItemImage> Resolve(ShoppingItemDto source, ShoppingItem destination, List<ItemImage> destMember, ResolutionContext context)
        {
            var images = new List<ItemImage>();

            foreach (var image in source.ImageFiles)
            {
                images.Add(new ItemImage 
                {
                    Id = source.Id,
                    ShoppingItemId = source.ShoppingListId,
                    ContentType = image.ContentType,
                    ImageData = Convert.FromBase64String(image.Base64Data)
                });
            }

            return images;
        }

        public List<ImageFile> Resolve(ShoppingItem source, ShoppingItemDto destination, List<ImageFile> destMember, ResolutionContext context)
        {
            var imageFiles = new List<ImageFile>();

            foreach (var image in source.Images) 
            {
                imageFiles.Add(new ImageFile 
                {
                    Id = source.Id,
                    Base64Data = Convert.ToBase64String(image.ImageData),
                    ContentType = image.ContentType
                });
            }

            return imageFiles;
        }
    }
}
