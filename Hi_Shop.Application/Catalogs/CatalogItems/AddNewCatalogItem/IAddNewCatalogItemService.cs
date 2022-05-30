using AutoMapper;
using Hi_Shop.Application.Dtos;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hi_Shop.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public interface IAddNewCatalogItemService
    {
        BaseDto<int> Execute(AddNewCatalogItemDto request);
    }

    public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IValidator<AddNewCatalogItemDto> _validator;

        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper, IValidator<AddNewCatalogItemDto> validator)
        {
            this.context = context;
            this.mapper = mapper;
            _validator = validator;
        }
        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            var validate = _validator.Validate(request);
            if (!validate.IsValid)
            {
                throw new Exception(validate.Errors.Select(s => s.ErrorMessage).ToString());
            }
            var catalogItem = mapper.Map<CatalogItem>(request);
            context.CatalogItems.Add(catalogItem);
            context.SaveChanges();
            return new BaseDto<int>(true, new List<string> { "با موفقیت ثبت شد" }, catalogItem.Id);
        }
    }

    public class AddNewCatalogItemFeature_Dto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
    }

    public class AddNewCatalogItemImage_Dto
    {
        public string Src { get; set; }
    }
}
