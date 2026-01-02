using Microsoft.AspNetCore.Mvc;
using HelloApi.Dtos;
using HelloApi.Services;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    private readonly IHelloService _service;

    public HelloController(IHelloService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string? firstname, 
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(firstname))
        {
            return BadRequest( new
            {
                error = "Query parameter 'firstname' is required.",
                example = "/api/hello?firstname=Esha"
            });
        }

        var request = new HelloRequestDto
        {
            FirstName = firstname
        };

        HelloResponseDto response = await _service.SayHiAsync(request, cancellationToken);

        return Ok(response);
    }
}