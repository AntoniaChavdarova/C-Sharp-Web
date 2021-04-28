namespace MyRecipes.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;
    using MyRecipes.Web.ViewModels.Search;

    public class SearchRecipesController : BaseController
    {
        private readonly IRecipesService recipesService;
        private readonly ISearchService searchService;

        public SearchRecipesController(IRecipesService recipesService, ISearchService searchService)
        {
            this.recipesService = recipesService;
            this.searchService = searchService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Ingredients = this.searchService.GetAllPopular<IngredientNameIdViewModel>(),
            };

            return this.View(viewModel);
        }

        // rezultata
        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Recipes = this.recipesService.GetByIngredients<RecipeInListViewModel>(input.Ingredients),
            };

            return this.View(viewModel);
        }
    }
}
