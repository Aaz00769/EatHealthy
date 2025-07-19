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

     

        
    }
}
