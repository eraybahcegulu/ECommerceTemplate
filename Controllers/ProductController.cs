using ECommerceTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceTemplate.Utility;

namespace ECommerceTemplate.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepository, IProductTypeRepository productTypeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _productRepository.GetAll(includeProps: "ProductType").ToList();
            return View(objProductList);
        }

        public IActionResult AddUpdate(int? id)
        {
            IEnumerable<SelectListItem> ProductTypeList = _productTypeRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Type,
                    Value = k.Id.ToString(),
                });

            ViewBag.ProductTypeList = ProductTypeList;

            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Product? productDb = _productRepository.Get(u => u.Id == id);
                if (productDb == null)
                {
                    return NotFound();
                }
                return View(productDb);
            }


        }



		[HttpPost]
		public IActionResult AddUpdate(Product product, IFormFile? file)
		{
			var errors = ModelState.Values.SelectMany(x => x.Errors);

			if (ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				string productPath = Path.Combine(wwwRootPath, @"img");

				if (file != null)
				{
					var fileExtension = Path.GetExtension(file.FileName).ToLower();
					if (fileExtension != ".png" && fileExtension != ".jpg")
					{
						TempData["danger"] = "The image to be uploaded must be in .png or .jpg format";
						return RedirectToAction("Index", "Product");
					}

					using (var fileStream = new FileStream(Path.Combine(productPath, file.FileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					product.ImgUrl = @"\img\" + file.FileName;
				}

				if (product.Id == 0)
				{
					_productRepository.Add(product);
					TempData["success"] = "New product added.";
				}
				else
				{
					_productRepository.Update(product);
					TempData["success"] = "Product updated.";
				}

				_productRepository.Save();
				return RedirectToAction("Index", "Product");
			}
			return View();
		}


		public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productDb = _productRepository.Get(u => u.Id == id);
            if (productDb == null)
            {
                return NotFound();
            }
            return View(productDb);
        }

        [HttpPost, ActionName("Remove")]
        public IActionResult RemovePOST(int? id)
        {
            Product? product = _productRepository.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _productRepository.Remove(product);
            _productRepository.Save();
            TempData["success"] = "Product removed.";
            return RedirectToAction("Index", "Product");
        }


    }
}
