﻿using Hi_Shop.Application.Discounts.AddNewDiscountService;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Admin.EndPoint.Binders
{
    public class DiscountEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            string fieldName = bindingContext.FieldName;

            AddNewDiscountDto discountDto = new AddNewDiscountDto()
            {
                CouponCode = bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.CouponCode)}").Values.ToString(),

                DiscountAmount = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.DiscountAmount)}").Values.ToString()),

                DiscountLimitationId = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),

                DiscountPercentage = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.DiscountPercentage)}").Values.ToString()),

                DiscountTypeId = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.DiscountTypeId)}").Values.ToString()),

                LimitationTimes = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.LimitationTimes)}").Values.ToString()),

                UsePercentage = bool.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.UsePercentage)}").FirstValue.ToString()),

                Name = bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.Name)}").Values.ToString(),

                ReqiresCouponCode = bool.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.ReqiresCouponCode)}").FirstValue.ToString()),

                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.EndDate)}").Values.ToString()),

                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                        .GetValue($"{fieldName}.{nameof(discountDto.StartDate)}").Values.ToString())
            };

            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("model.AppliedToCatalogItem");

            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                discountDto.AppliedToCatalogItem =
                    bindingContext.ValueProvider
                        .GetValue($"{fieldName}.{nameof(discountDto.AppliedToCatalogItem)}")
                        .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            }

            bindingContext.Result = ModelBindingResult.Success(discountDto);
            return Task.CompletedTask;
        }
    }
}
