using Moq;
using MyRecipes.Data.Common.Repositories;
using MyRecipes.Data.Models;
using MyRecipes.Web.ViewModels.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyRecipes.Services.Data.Tests
{
    public class RecipeServiceTests
    {
        private readonly List<Recipe> list = new List<Recipe>();
        private readonly Mock<IDeletableEntityRepository<Recipe>> mockRepoRecipe;
        private readonly Mock<IDeletableEntityRepository<Ingredient>> mockRepoIngredients;
       

        public RecipeServiceTests()
        {
            this.mockRepoRecipe = new Mock<IDeletableEntityRepository<Recipe>>();
            this.mockRepoIngredients = new Mock<IDeletableEntityRepository<Ingredient>>();
           
        }

       // mockRepo.Setup(x => x.All()).Returns(this.list.AsQueryable());
       // mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => this.list.Add(vote));

//        [Fact]
//        public void GetAllRecipesInDBWhenGetAllMethodIsInvoke()
//        {
//            this.mockRepoRecipe.Setup(x => x.AllAsNoTracking()).Returns(this.list.AsQueryable());
//            this.mockRepoRecipe.Setup(x => x.AddAsync(It.IsAny<Recipe>())).Callback((Recipe recipe) => this.list.Add(recipe));

//            var service = new RecipesService(this.mockRepoRecipe.Object, this.mockRepoIngredients.Object);
//            var recipe1 = new Recipe
//            {
//                Name = "Musaka",
//            };

//            var recipe2 = new Recipe
//            {
//                Name = "Supa",
//            };

//            var viewModel = new RecipeInListViewModel
//            {
//                Name = recipe1.Name,
//            };
//            this.list.Add(recipe1);
//            //this.list.Add(recipe2);
//            service.GetAll<RecipeInListViewModel>(1, 2);
//            ;

//          // Assert.Equal("Musaka" , service.)

       // }

    }
}
