namespace MyRecipes.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using Xunit;

    public class VoteServiceTests
   {
       private readonly List<Vote> list = new List<Vote>();

       [Fact]
       public async Task WhenUserVotes2TimesOnly1VoteShouldCount()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(this.list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => this.list.Add(vote));
            var service = new VoteService(mockRepo.Object);

            // Act
            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 5);

            Assert.Equal(1, this.list.Count());
            Assert.Equal(5, this.list.First().Value);
        }

       [Fact]
       public async Task When2UsersVoteForSameRecipeGetAverageValueCorrect()
        {
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(this.list.AsQueryable());
           // mockRepo.Setup(x => x.To<>)
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => this.list.Add(vote));

            var service = new VoteService(mockRepo.Object);

            await service.SetVoteAsync(2, "1", 5);
            await service.SetVoteAsync(2, "3", 3);

            Assert.Equal(4, service.GetAverageVote(2));
        }
    }
}
