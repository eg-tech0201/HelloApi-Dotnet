using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? firstname)
    {
        if (string.IsNullOrWhiteSpace(firstname))
        {
            return BadRequest( new
            {
                error = "Query parameter 'firstname' is required.",
                example = "/api/hello?firstname=Esha"
            });
        }

        return Ok(new
        {
            firstname,
            message = $"Hi {firstname}"
        });
    }
}