using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }
        public IActionResult login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
