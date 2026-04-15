using Microsoft.AspNetCore.Mvc;
using Task1WebService.Models;
using Task1WebService.Storage;

namespace Task1WebService.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ItemStore.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = ItemStore.GetById(id);

            if (item == null)
            {
                return NotFound(new ErrorResponse
                {
                    Code = "not_found",
                    Message = "Item not found",
                    RequestId = HttpContext.Items["RequestId"]?.ToString()
                });
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "validation_error",
                    Message = "Name is required",
                    RequestId = HttpContext.Items["RequestId"]?.ToString()
                });
            }

            if (item.Price < 0)
            {
                return BadRequest(new ErrorResponse
                {
                    Code = "validation_error",
                    Message = "Price must be non-negative",
                    RequestId = HttpContext.Items["RequestId"]?.ToString()
                });
            }

            var created = ItemStore.Add(item);
            return Ok(created);
        }
    }
}