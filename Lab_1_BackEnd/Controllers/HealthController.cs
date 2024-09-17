using Microsoft.AspNetCore.Mvc;

namespace Lab_1_BackEnd.Controllers;

[Route("API/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet("/healthcheck")]
    public IActionResult Get()
    {
        string status = "Healthy";
        DateTime data = DateTime.Now;
        
        return Ok(new {
            status, data
        });
    }
}