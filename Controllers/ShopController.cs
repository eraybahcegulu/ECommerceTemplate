using ECommerceTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceTemplate.Controllers
{
	public class ShopController : Controller
	{
		private readonly IProductRepository _productRepository;

		public ShopController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}



		public IActionResult Index()
		{

			List<Product> allProducts = _productRepository.GetAll().ToList();
			return View(allProducts);
		}

        public IActionResult GraphicsCard()
        {
            List<Product> graphicsCardProducts = _productRepository.GetAll(includeProps: "ProductType").Where(p => p.ProductType != null && p.ProductType.Type == "Graphics Card").ToList();


            return View(graphicsCardProducts);

        }

        public IActionResult Motherboard()
        {
            List<Product> motherboardProducts = _productRepository.GetAll(includeProps: "ProductType").Where(p => p.ProductType != null && p.ProductType.Type == "Motherboard").ToList();


            return View(motherboardProducts);

        }

        public IActionResult Ram()
        {
            List<Product> ramProducts = _productRepository.GetAll(includeProps: "ProductType").Where(p => p.ProductType != null && p.ProductType.Type == "RAM").ToList();


            return View(ramProducts);

        }

        public IActionResult Processor()
        {
            List<Product> processorProducts = _productRepository.GetAll(includeProps: "ProductType").Where(p => p.ProductType != null && p.ProductType.Type == "Processor").ToList();


            return View(processorProducts);

        }


    }
}
