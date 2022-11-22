//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using TestProject.Solution.Data.Entity;
//using TestProject.Solution.DTO;
//using TestProject.Solution.Services;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace TestProject.Solution.API.Controllers
//{
//	//[Authorize]
//	[Route("api/[controller]")]
//	[ApiController]
//	public class UsersController : ControllerBase
//	{
//		private readonly IJWTManagerRepository _jWTManager;

//		public UsersController(IJWTManagerRepository jWTManager)
//		{
//			this._jWTManager = jWTManager;
//		}

//		[HttpGet]
//		public List<string> Get()
//		{
//			var users = new List<string>
//		{
//			"Satinder Singh",
//			"Amit Sarna",
//			"Davin Jon"
//		};

//			return users;
//		}

//		[AllowAnonymous]
//		[HttpPost]
//		[Route("authenticate")]
//		public IActionResult Authenticate(UserInputDto usersdata)
//		{
//			var token = _jWTManager.Authenticate(usersdata);

//			if (token == null)
//			{
//				return Unauthorized();
//			}

//			return Ok(token);
//		}
//	}
//}
