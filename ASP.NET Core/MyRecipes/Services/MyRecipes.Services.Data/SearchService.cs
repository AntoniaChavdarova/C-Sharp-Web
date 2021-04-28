namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public SearchService(IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.ingredientRepository.All()
                //.Where(x => x.Recipes.Count() > 10)
                .OrderByDescending(x => x.Recipes.Count())
                .To<T>()
                .ToList();
        }
    }
}
