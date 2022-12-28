using Hi_Shop.Application.BasketsService;
using Hi_Shop.Application.Discounts;
using Hi_Shop.Application.Orders;
using Hi_Shop.Application.Payments;
using Hi_Shop.Application.Users;
using Hi_Shop.Domain.Order;
using Hi_Shop.Domain.Users;
using Hi_Shop.EndPoint.Models.ViewModels.Baskets;
using Hi_Shop.EndPoint.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private readonly IUserAddressService userAddressService;
        private readonly IOrderService orderService;
        private readonly IPaymentService paymentService;
        private readonly IDiscountService discountService;
        private readonly UserManager<User> userManager;
        private string userId = null;

        public BasketController(IBasketService basketService,
            SignInManager<User> signInManager,
            IUserAddressService userAddressService,
            IOrderService orderService,
            IPaymentService paymentService,
            IDiscountService discountService,
            UserManager<User> userManager)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
            this.userAddressService = userAddressService;
            this.orderService = orderService;
            this.paymentService = paymentService;
            this.discountService = discountService;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(int catalogItemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            basketService.AddItemToBasket(basket.Id,catalogItemId,quantity);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RemoveItemFromBasket(int itemId)
        {
            basketService.RemoveItemFromBasket(itemId);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SetQuantity(int basketItemId, int quantity)
        {
            return Json(basketService.SetQuantities(basketItemId, quantity));
        }

        public IActionResult ShippingPayment()
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            string userId = ClaimUtility.GetUserId(User);
            model.Basket = basketService.GetBasketForUser(userId);
            model.UserAddresses = userAddressService.GetAddress(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult ShippingPayment(int Address , PaymentMethod PaymentMethod)
        {
            string userId = ClaimUtility.GetUserId(User);
            var basket = basketService.GetBasketForUser(userId);
            int orderId = orderService.CreateOrder(basket.Id, Address, PaymentMethod);
            if (PaymentMethod == PaymentMethod.OnlinePayment)
            {
                //sabte pardakht
                var payment = paymentService.PayForOrder(orderId);

                //ersal be dargahe pardakht
                return RedirectToAction("Index","Pay",new {PaymentId = payment.PaymentId});
            }
            else
            {
                //safhe sefareshat man
                return RedirectToAction("Index", "Orders", new { area = "customers" });
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult ApplyDiscount(string couponCode, int basketId)
        {
            var user = userManager.GetUserAsync(User).Result;
            var validDiscount = discountService.IsDiscountValid(couponCode, user);
            if (validDiscount.IsSuccess)
            {
                discountService.ApplyDiscountInBasket(couponCode, basketId);
            }
            else
            {
                TempData["InvalidMessage"] = String.Join(Environment.NewLine,
                    validDiscount.Message.Select(a => String.Join(",", a)));
            }
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult RemoveDiscount(int id)
        {
            discountService.RemoveDiscountFromBasket(id);
            return RedirectToAction(nameof(Index));
        }




        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User);
                return basketService.GetOrCreateBasketForUser(userId);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(userId);
            }
        }

        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                userId = Request.Cookies[basketCookieName];
            }

            if (userId != null) return;
            userId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(basketCookieName, userId, cookieOptions);

        }
    }
}
