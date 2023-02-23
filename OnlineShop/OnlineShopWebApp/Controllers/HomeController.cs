﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public HomeController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(Mapping.ToProductViewModels(products));
        }

        [HttpPost]
        public IActionResult SearchByName(string searchname)
        {
            var findProduct = productsRepository.TryGetByName(searchname);
            return View(Mapping.ToProductViewModels(findProduct));
        }
    }
}
