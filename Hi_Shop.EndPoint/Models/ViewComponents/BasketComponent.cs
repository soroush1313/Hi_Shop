using System.Security.Claims;
using Hi_Shop.Application.BasketsService;
using Hi_Shop.EndPoint.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Models.ViewComponents
{
    public class BasketComponent : ViewComponent
    {
        private readonly IBasketService basketService;

        public BasketComponent(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        private ClaimsPrincipal userClaimsPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;

            if (User.Identity.IsAuthenticated)
            {
                basket = basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimsPrincipal));
            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    basket = basketService.GetBasketForUser(buyerId);

                }
            }
            return View(viewName:"BasketComponent",model:basket);
        }
    }
}
