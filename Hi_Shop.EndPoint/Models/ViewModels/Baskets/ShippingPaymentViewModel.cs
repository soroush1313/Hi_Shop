using Hi_Shop.Application.BasketsService;
using Hi_Shop.Application.Users;

namespace Hi_Shop.EndPoint.Models.ViewModels.Baskets
{
    public class ShippingPaymentViewModel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddresses { get; set; }
    }
}
