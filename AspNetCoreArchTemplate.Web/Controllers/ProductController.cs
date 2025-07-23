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
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                await _productService.AddProductAsync(inputModel);
                return RedirectToAction(nameof(ShowProducts));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return View(inputModel);
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

        [HttpPost]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var success = await _productService.SoftDeleteProductAsync(id);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(ShowProducts));
        }
        [HttpPost]
        public async Task<IActionResult> HardDelete(Guid id)
        {
            var success = await _productService.HardDeleteProductAsync(id);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(ShowDeletedProducts));
        }
        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var success = await _productService.RestoreProductAsync(id);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(ShowDeletedProducts));
        }
        [HttpGet]
        public async Task<IActionResult> ShowDeletedProducts()
        {
            var deletedProducts = await _productService.GetAllDeletedProductAsync();
            return View(deletedProducts);
        }
    }
}
