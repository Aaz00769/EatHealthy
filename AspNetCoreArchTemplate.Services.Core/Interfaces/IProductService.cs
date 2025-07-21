

namespace EatHealthy.Services.Core.Interfaces
{
    using EatHealthy.Web.ViewModels.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductAsync();

        Task<IEnumerable<ProductViewModel>> GetAllDelitedProductAsync();

        Task AddProductAsync(ProductFormInputModel inputModel);

        Task<bool> ProductExist(string name);

        Task EditProductAsync(Guid id, ProductFormInputModel inputModel);

        Task<ProductFormInputModel?> GetProductByIdAsync(Guid id);
        
        Task<bool> SoftDeletProductAsync(Guid id);

        Task<bool> HardDeleteProductAsync(Guid id);

        Task<bool> RestoreProductAsync(Guid id);

    }
}
