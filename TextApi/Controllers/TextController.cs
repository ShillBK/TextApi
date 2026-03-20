using Microsoft.AspNetCore.Mvc;
using TextApi.Models;

namespace TextApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextController : ControllerBase
    {
        [HttpPost("uppercase")]
        public IActionResult ConvertToUpper([FromBody] TextRequest request)
        {
            if (string.IsNullOrEmpty(request.InputText))
                return BadRequest("Input text is required");

            var result = request.InputText.ToUpper();

            return Ok(new
            {
                original = request.InputText,
                uppercased = result
            });
        }
    }
}
