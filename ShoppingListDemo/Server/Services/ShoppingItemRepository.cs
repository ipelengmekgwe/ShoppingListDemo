using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingListDemo.Server.Data;
using ShoppingListDemo.Server.Models;
using ShoppingListDemo.Server.Services.Interfaces;
using ShoppingListDemo.Shared;
using System.Security.Claims;

namespace ShoppingListDemo.Server.Services
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public ShoppingItemRepository(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor accessor)
        {
            _context = context;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task Create(ShoppingItemDto shoppingItemDto)
        {
            var shoppingItem = _mapper.Map<ShoppingItemDto, ShoppingItem>(shoppingItemDto);
            shoppingItem.DateCreated = DateTime.Now;
            shoppingItem.LastModified = DateTime.Now;
            shoppingItem.UserId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null; ;

            await _context.ShoppingItems.AddAsync(shoppingItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingItem = await _context.ShoppingItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (shoppingItem != null)
            {
                _context.ShoppingItems.Remove(shoppingItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteImage(int id)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var itemImage = await _context.ItemImages.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (itemImage != null)
            {
                _context.ItemImages.Remove(itemImage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ShoppingItemDto> Get(int id)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingItem = await _context.ShoppingItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (shoppingItem != null)
            {
                return _mapper.Map<ShoppingItem, ShoppingItemDto>(shoppingItem);
            }

            return new ShoppingItemDto { Id = id };
        }

        public async Task<IEnumerable<ShoppingItemDto>> GetAll()
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _mapper
                .Map<IEnumerable<ShoppingItem>, IEnumerable<ShoppingItemDto>>(
                    await _context.ShoppingItems.Include(x => x.Images).Where(x => x.UserId == userId).ToListAsync());
        }

        public async Task Update(int id, ShoppingItemDto shoppingItemDto)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingItemEntity = await _context.ShoppingItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (shoppingItemEntity != null)
            {
                var shoppingItem = _mapper.Map(shoppingItemDto, shoppingItemEntity);
                shoppingItem.LastModified = DateTime.Now;

                _context.ShoppingItems.Update(shoppingItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
