using System.Security.Claims;
using Hi_Shop.Application.Users;
using Hi_Shop.EndPoint.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserAddressService userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            this.userAddressService = userAddressService;
        }
        public IActionResult Index()
        {
            var addresses = userAddressService.GetAddress(ClaimUtility.GetUserId(User));
            return View(addresses);
        }

        public IActionResult AddNewAddress()
        {
            return View(new AddUserAddressDto());
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDto address)
        {
            string userId = ClaimUtility.GetUserId(User);
            address.UserId = userId;
            userAddressService.AddNewAddress(address);
            return RedirectToAction(nameof(Index));
        }

    }
}
