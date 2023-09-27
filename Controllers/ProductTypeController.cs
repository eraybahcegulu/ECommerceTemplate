using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECommerceTemplate.Models;
using ECommerceTemplate.Utility;
using System.Data;
using ECommerceTemplate.Migrations;

namespace ECommerceTemplate.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository context)
        {
            _productTypeRepository = context;
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Index()
        {
            List<ProductType> objProductTypeList = _productTypeRepository.GetAll().ToList();
            return View(objProductTypeList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepository.Add(productType);
                _productTypeRepository.Save();
                TempData["success"] = "The new product type has been created successfully.";
                return RedirectToAction("Index", "ProductType");
            }
            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProductType? productTypeDb = _productTypeRepository.Get(u => u.Id == id);
            if (productTypeDb == null)
            {
                return NotFound();
            }
            return View(productTypeDb);
        }

        [HttpPost, ActionName("Remove")]
        public IActionResult RemovePOST(int? id)
        {
            ProductType? productType = _productTypeRepository.Get(u => u.Id == id);
            if (productType == null)
            {
                return NotFound();
            }
            _productTypeRepository.Remove(productType);
            _productTypeRepository.Save();
            TempData["success"] = "Product type removed successfully.";
            return RedirectToAction("Index", "ProductType");
        }
    }
}
