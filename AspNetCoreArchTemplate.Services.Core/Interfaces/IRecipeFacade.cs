using EatHealthy.Web.ViewModels.Product;
using EatHealthy.Web.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Services.Core.Interfaces
{
    public interface IRecipeFacade
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductAsync();
        Task CreateRecipeAsync(Guid userId, RecipeFormInputModel model);
    }

}
