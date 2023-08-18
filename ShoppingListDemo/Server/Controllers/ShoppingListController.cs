using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListDemo.Server.Services.Interfaces;
using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListController(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shoppingLists = await _shoppingListRepository.GetAll();
            return Ok(shoppingLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(int? id)
        {
            if (id == null) return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Invalid Id",
                StatusCode = StatusCodes.Status400BadRequest
            });

            var shoppingList = await _shoppingListRepository.Get(id.Value);
            return Ok(shoppingList);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ShoppingListDto shoppingListDto)
        {
            if (!ModelState.IsValid) return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Error occurred while creating shopping list",
                StatusCode = StatusCodes.Status400BadRequest
            });

            await _shoppingListRepository.Create(shoppingListDto);

            return Ok();
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShoppingListDto shoppingListDto)
        {
            if (!ModelState.IsValid) return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Error occurred while updating shopping list",
                StatusCode = StatusCodes.Status400BadRequest
            });

            await _shoppingListRepository.Update(id, shoppingListDto);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Error occurred while deleting shopping list",
                StatusCode = StatusCodes.Status400BadRequest
            });

            await _shoppingListRepository.Delete(id.Value);

            return Ok();
        }
    }
}
