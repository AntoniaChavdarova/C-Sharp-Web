namespace MyRecipes.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels.Recipes;

    public class ListViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }
    }
}
