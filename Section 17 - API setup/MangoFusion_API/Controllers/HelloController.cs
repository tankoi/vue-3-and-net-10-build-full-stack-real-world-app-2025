using Microsoft.AspNetCore.Mvc;

namespace MangoFusion_API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HelloController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello, World!");
		}
	}
}