using Dto.Payment;
using Hi_Shop.Application.Payments;
using Hi_Shop.EndPoint.Utilities;
using Microsoft.AspNetCore.Mvc;
using ZarinPal.Class;

namespace Hi_Shop.EndPoint.Controllers
{
    public class PayController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;


        private readonly IConfiguration configuration;
        private readonly IPaymentService paymentService;
        private readonly string merchendId;

        public PayController(IConfiguration configuration, IPaymentService paymentService)
        {
            this.configuration = configuration;
            this.paymentService = paymentService;
            merchendId = configuration["ZarinpalMerchendId"];

            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(Guid paymentId)
        {
            var payment = paymentService.GetPayment(paymentId);
            if (payment == null) return NotFound();
            string userId = ClaimUtility.GetUserId(User);
            if (userId != payment.UserId) return BadRequest();
            string callbackUrl = Url.Action(nameof(Verify), "Pay", new { payment.Id }, protocol: Request.Scheme);
            var resultZarinpalRequest = await _payment.Request(new DtoRequest()
                {
                    Amount = payment.Amount,
                    CallbackUrl = callbackUrl,
                    Description = payment.Description,
                    Email = payment.Email,
                    MerchantId = merchendId,
                    Mobile = payment.PhoneNumber
                }, Payment.Mode.zarinpal
            );
            return Redirect($"https://zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
        }

        public IActionResult Verify()
        {
            return View();
        }
    }
}
