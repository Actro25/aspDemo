using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GreetGet(int num1, int num2, char key)
        {
            string result = "";

            switch (key)
            {
                case '+':
                    result = $"Sum = {num1 + num2}";
                    break;
                case '-':
                    result = $"Subtract = {num1 - num2}";
                    break;
                case '*':
                    result = $"Multiply = {num1 * num2}";
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        return BadRequest("Division by zero is not allowed.");
                    }
                    result = $"Divide = {num1 / num2}";
                    break;
            }
            return Ok(result);
        }
    }
}
