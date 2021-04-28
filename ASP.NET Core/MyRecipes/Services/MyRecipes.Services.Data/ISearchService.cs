namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;

    public interface ISearchService
    {
        IEnumerable<T> GetAllPopular<T>();
    }
}
