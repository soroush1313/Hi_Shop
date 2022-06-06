using Hi_Shop.Application.BasketsService;
using Hi_Shop.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private string UserId = null;

        public BasketController(IBasketService basketService, SignInManager<User> signInManager)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(int catalogItemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            basketService.AddItemToBasket(basket.Id,catalogItemId,quantity);
            return RedirectToAction(nameof(Index));
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                return basketService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(UserId);
            }
        }

        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                UserId = Request.Cookies[basketCookieName];
            }

            if (UserId != null) return;
            UserId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(basketCookieName, UserId, cookieOptions);

        }
    }
}
