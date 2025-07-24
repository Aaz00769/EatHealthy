using EatHealthy.Services.Core.Interfaces;
using EatHealthy.Web.ViewModels.Product;
using EatHealthy.Web.ViewModels.Recipe;

public class RecipeFacade : IRecipeFacade
{
    private readonly IRecipeService _recipeService;
    private readonly IProductService _productService;

    public RecipeFacade(IRecipeService recipeService, IProductService productService)
    {
        _recipeService = recipeService;
        _productService = productService;
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductAsync()
    {
        return await _productService.GetAllProductAsync();

        
    }

    public async Task CreateRecipeAsync(Guid userId, RecipeFormInputModel model)
    {
        await _recipeService.AddRecipeAsync(userId, model);
    }

    public async Task EditRecipeAsync(Guid id, RecipeFormInputModel model)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<RecipeViewModel>> GetUserRecipesAsync(Guid userId)
    {
        return await _recipeService.GetUserRecipesAsync(userId);
    }
}
