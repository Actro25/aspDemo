using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerForCRUD : ControllerBase
    {
        private static List<string> list = new List<string>();

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return list;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            list.Add(value);
            return Ok(new { message = $"Successfully added: {value}" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string value)
        {
            if (id < 0 || id >= list.Count)
            {
                return NotFound(new { message = "Item not found" });
            }

            list[id] = value;
            return Ok(new { message = $"Successfully updated item at index {id} with value: {value}" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= list.Count)
            {
                return NotFound(new { message = "Item not found" });
            }

            list.RemoveAt(id);
            return Ok(new { message = "Successfully deleted" });
        }
    }
}
