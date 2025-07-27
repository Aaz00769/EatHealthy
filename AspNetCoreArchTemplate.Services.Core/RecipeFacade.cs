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

    //edits recipe 
    public async Task EditRecipeAsync(Guid userId, RecipeFormInputModel model)
    {
        
        if (model == null) throw new ArgumentNullException(nameof(model));

        await _recipeService.EditRecipeAsync(userId, model);
    }

    //returns all the recipes of a user
    public async Task<IEnumerable<RecipeViewModel>> GetUserRecipesAsync(Guid userId)
    {
        return await _recipeService.GetUserRecipesAsync(userId);
    }
    // returns a receie by its Id 
    public async Task<RecipeFormInputModel?> ShowRecipeByIdAsync(Guid userId, Guid id)
    {
        return await _recipeService.ShowRecipeByIdAsync(userId, id);
    }

    

    public async Task<bool> SoftDeleteRecipeAsync(Guid id)
    {
        return await _recipeService.SoftDeleteRecipeAsync(id);
    }
}
