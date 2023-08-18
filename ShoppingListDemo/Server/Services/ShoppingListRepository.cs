using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingListDemo.Server.Data;
using ShoppingListDemo.Server.Models;
using ShoppingListDemo.Server.Services.Interfaces;
using ShoppingListDemo.Shared;
using System.Security.Claims;

namespace ShoppingListDemo.Server.Services
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public ShoppingListRepository(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor accessor)
        {
            _context = context;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task Create(ShoppingListDto shoppingListDto)
        {
            var shoppingList = _mapper.Map<ShoppingListDto, ShoppingList>(shoppingListDto);
            shoppingList.DateCreated = DateTime.Now;
            shoppingList.LastModified = DateTime.Now;
            shoppingList.UserId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            await _context.ShoppingLists.AddAsync(shoppingList);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingList = await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (shoppingList != null)
            {
                _context.ShoppingLists.Remove(shoppingList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ShoppingListDto> Get(int id)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingList = await _context.ShoppingLists
                .Include(x => x.Items)
                .ThenInclude(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (shoppingList != null)
            {
                return _mapper.Map<ShoppingList, ShoppingListDto>(shoppingList);
            }

            return new ShoppingListDto { Id = id };
        }

        public async Task<IEnumerable<ShoppingListDto>> GetAll()
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _mapper
                .Map<IEnumerable<ShoppingList>, IEnumerable<ShoppingListDto>>(
                    await _context.ShoppingLists.Where(x => x.UserId == userId).ToListAsync());
        }

        public async Task Update(int id, ShoppingListDto shoppingListDto)
        {
            var userId = _accessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingListEntity = await _context.ShoppingLists
                .Include(x => x.Items)
                .ThenInclude(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (shoppingListEntity != null)
            {
                var shoppingList = _mapper.Map(shoppingListDto, shoppingListEntity);
                shoppingList.LastModified = DateTime.Now;

                shoppingList.Items.ForEach(x =>
                {
                    x.ShoppingListId = shoppingList.Id;
                    x.LastModified = DateTime.Now;
                    x.UserId = userId;

                    x.Images.ForEach(i =>
                    {
                        i.ShoppingItemId = x.Id;
                        i.LastModified = DateTime.Now;
                        i.UserId = userId;
                    });
                });

                _context.ShoppingLists.Update(shoppingList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
