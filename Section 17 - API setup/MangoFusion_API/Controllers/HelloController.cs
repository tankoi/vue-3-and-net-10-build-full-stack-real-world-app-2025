using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
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