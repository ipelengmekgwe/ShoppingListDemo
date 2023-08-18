using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListDemo.Server.Services;
using ShoppingListDemo.Server.Services.Interfaces;
using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingItemController : ControllerBase
    {
        private readonly IShoppingItemRepository _shoppingItemRepository;

        public ShoppingItemController(IShoppingItemRepository shoppingItemRepository)
        {
            _shoppingItemRepository = shoppingItemRepository;
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Error occurred while deleting shopping item",
                StatusCode = StatusCodes.Status400BadRequest
            });

            await _shoppingItemRepository.Delete(id.Value);

            return Ok();
        }

        [HttpDelete("deleteimage/{id}")]
        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null) return BadRequest(new ErrorResponse
            {
                ErrorMessage = "Error occurred while deleting item image",
                StatusCode = StatusCodes.Status400BadRequest
            });

            await _shoppingItemRepository.DeleteImage(id.Value);

            return Ok();
        }
    }
}
