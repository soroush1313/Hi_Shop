﻿using Hi_Shop.Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Hi_Shop.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Microsoft.AspNetCore.Mvc;

namespace Hi_Shop.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPdpService;

        public ProductController(IGetCatalogItemPLPService getcatalogItemPlpService , IGetCatalogItemPDPService getCatalogItemPdpService)
        {
            this.getCatalogItemPLPService = getcatalogItemPlpService;
            this.getCatalogItemPdpService = getCatalogItemPdpService;
        }
        public IActionResult Index(int page = 1 , int pageSize = 20)
        {
            var data = getCatalogItemPLPService.Execute(page, pageSize);
            return View(data);
        }

        public IActionResult Details(int Id)
        {
            var data = getCatalogItemPdpService.Execute(Id);
            return View(data);
        }
    }
}
