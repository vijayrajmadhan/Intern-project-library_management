using Microsoft.AspNetCore.Mvc;
using YtBookStore.Models;

namespace YtBookStore.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}

		public List<UserModel> PutValue()
		{
			var users = new List<UserModel>()
			{
				new UserModel { Id = 1,Username="Vijay",Password="24-Aug-2000"},
				new UserModel { Id = 2,Username="Chakra",Password="11-Oct-2003"},
				new UserModel { Id = 3,Username="Sarath",Password="18-Jan-1994"}
			};
			return users;
		}

		[HttpPost]
		public IActionResult verify(UserModel usr)
		{
			var u=PutValue();

			var ue = u.Where(u => u.Username.Equals(usr.Username));

			var up = ue.Where(p => p.Password.Equals(usr.Password));
			if(up.Count() ==1) 
			{
				ViewBag.message = "Login Success";
				return RedirectToAction("Index","Home");
			}
			else
			{
				ViewBag.message = ("Login Failed");
				return View("Login");
			}
		}

		[HttpPost]
		public IActionResult User()
		{
			return RedirectToAction("Index2", "User");
		}
	}
}
