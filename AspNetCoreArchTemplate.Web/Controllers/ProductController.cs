using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace EatHealthy.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult>ShowProducts()
        {
            IEnumerable<ProductViewModel> allProducts
                = await this._productService.GetAllProductAsync();

            var viewModel = new ProductListViewModel
            {
                Products = allProducts,
                TotalCount =(allProducts).Count()
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductFormInputModel inputModel)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }
           
            bool exists=await this._productService.ProductExist(inputModel.ProductName);

            if (exists) 
            {
                this.ModelState.AddModelError(nameof(inputModel.ProductName), "A product with this name already exists.");
                return this.View(inputModel);
            }

            try
            {
                await this._productService.AddProductAsync(inputModel);

                return RedirectToAction(nameof(ShowProducts));
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty,e.Message);
                return this.View(inputModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductFormInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                await _productService.EditProductAsync(inputModel.ProductId, inputModel);
                return RedirectToAction(nameof(ShowProducts));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while editing the product.");
                return View(inputModel);
            }
        }

    }
}
