namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
