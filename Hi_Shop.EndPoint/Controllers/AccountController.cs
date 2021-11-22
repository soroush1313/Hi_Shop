using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
    }
}
