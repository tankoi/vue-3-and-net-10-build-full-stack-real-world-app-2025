using MangoFusion_API.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangoFusion_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthTestController
	{
		[HttpGet]
		[Authorize]
		public ActionResult<string> GetSomething()
		{
			return "You are authorized user";
		}
		
		[HttpGet("{someValue:int}")]
		[Authorize(Roles = SD.Role_Admin)]
		public ActionResult<string> GetSomething(int someValue)
		{
			return "You are authorized user with role of Admin";
		}
	}
}