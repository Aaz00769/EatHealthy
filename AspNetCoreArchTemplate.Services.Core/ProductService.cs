

namespace EatHealthy.Services.Core
{
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data;
    using EatHealthy.Data.Models;
    using EatHealthy.Services.Core.Interfaces;
    using EatHealthy.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; 
        
        public ProductService(IProductRepository context)
        {
            _productRepository = context;
        }

        
        //Shows all available product from world list
        public async Task<IEnumerable<ProductViewModel>> GetAllProductAsync()
        {
            IEnumerable<ProductViewModel> allProducts = await this._productRepository
                .All()
                .Where(p => !p.IsDeleted && p != null)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,  
                    Calories = p.Calories.ToString(),

                })
                .ToListAsync();

           
            return allProducts;
        }
        //adds a product to world list
        public async Task AddProductAsync(ProductFormInputModel inputModel)
        {
            bool exists = await _productRepository
                .All()
                .AnyAsync(p => p.Name == inputModel.ProductName && !p.IsDeleted);

            if (exists)
            {
                throw new InvalidOperationException("A product with this name already exists.");
            }

            Product newProduct = new Product()
            {
                Name = inputModel.ProductName,
                Calories = inputModel.Calories,
                Proteins = inputModel.Proteins,
                Fats = inputModel.Fats,
                Carbohydrates = inputModel.Carbohydrates
            };

            await _productRepository.AddAsync(newProduct);
            await _productRepository.SaveChangesAsync();
        }
        //Edits a product 
        public async Task EditProductAsync(Guid id, ProductFormInputModel inputModel)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            product.Name = inputModel.ProductName;
            product.Calories = inputModel.Calories;
            product.Proteins = inputModel.Proteins;
            product.Fats = inputModel.Fats;
            product.Carbohydrates = inputModel.Carbohydrates;

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
        }
        //Return a product 
        public async Task<ProductFormInputModel?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductFormInputModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Calories = product.Calories,
                Fats = product.Fats,
                Proteins = product.Proteins,
                Carbohydrates = product.Carbohydrates
            };
        }
        //SoftDelites a product
        public async Task<bool> SoftDeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null || product.IsDeleted) return false;

            product.IsDeleted = true;
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
        //FullDelete product
        public async Task<bool> HardDeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            await _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
        //See all soft delited product
        public async Task<IEnumerable<ProductViewModel>> GetAllDeletedProductAsync()
        {
            return await _productRepository
                .All()
                .Where(p => p.IsDeleted)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Calories = p.Calories.ToString()
                })
                .ToListAsync();
        }
        //Resotre a soft delited Product
        public async Task<bool> RestoreProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null || !product.IsDeleted) return false;

            product.IsDeleted = false;
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
    }

}
