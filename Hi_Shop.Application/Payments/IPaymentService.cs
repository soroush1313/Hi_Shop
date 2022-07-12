using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Order;
using Hi_Shop.Domain.Payments;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Application.Payments
{
    public interface IPaymentService
    {
        PaymentOfOrderDto PayForOrder(int orderId);
        PaymentDto GetPayment(Guid Id);
    }

    public class PaymentService : IPaymentService
    {
        private readonly IDataBaseContext context;
        private readonly IIdentityDataBaseContext identityContext;

        public PaymentService(IDataBaseContext context, IIdentityDataBaseContext identityDatabaseContext)
        {
            this.context = context;
            this.identityContext = identityDatabaseContext;
        }

        public PaymentDto GetPayment(Guid Id)
        {
            var payment = context.Payments
                .Include(p => p.Order)
                .ThenInclude(p => p.OrderItems)
                .SingleOrDefault(p => p.Id == Id);

            var user = identityContext.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);
            string description = $"پرداخت سفارش شماره {payment.OrderId}" + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;
            foreach (var item in payment.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $"-{item}";
            }

            PaymentDto paymentDto = new PaymentDto
            {
                Amount = payment.Order.TotalPrice(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id,
                Id = payment.Id,
                Description = description
            };
            return paymentDto;
        }

        public PaymentOfOrderDto PayForOrder(int orderId)
        {
            var order = context.Orders
                .Include(p => p.OrderItems)
                .SingleOrDefault(p => p.Id == orderId);
            if (order == null)
                throw new Exception("");
            var payment = context.Payments.SingleOrDefault(p => p.OrderId == order.Id);
            if (payment == null)
            {
                payment = new Payment(order.TotalPrice(), order.Id);
                context.Payments.Add(payment);
                context.SaveChanges();
            }

            return new PaymentOfOrderDto()
            {
                Amount = payment.Amount,
                PaymentId = payment.Id,
                PaymentMethod = order.PaymentMethod
            };
        }
    }

    public class PaymentOfOrderDto
    {
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

    public class PaymentDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public string UserId { get; set; }
    }
}
