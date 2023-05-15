using Moq;
using NUnit.Framework;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTest
    {
        [Test]
        public void CreateFriendMustReturnCorrectVal()
        {
            FriendService friendService = new FriendService();

            List<FriendEntity> friends = new List<FriendEntity>()
            {
                new FriendEntity() { id = 0, user_id = 0, friend_id = 2 },
                new FriendEntity() { id = 1, user_id = 1, friend_id = 1 },
                new FriendEntity() { id = 2, user_id = 2, friend_id = 0 }

            };

            var mockFriendRepo = new Mock<IFriendRepository>();
            mockFriendRepo.Setup(x => x.FindAllByUserId(1)).Returns(friends);

            Assert.That(mockFriendRepo.Object.FindAllByUserId(1).Any(f => f.id == 0));
            Assert.That(mockFriendRepo.Object.FindAllByUserId(1).Any(f => f.id == 1));
            Assert.That(mockFriendRepo.Object.FindAllByUserId(1).Any(f => f.id == 2));
        }
    }
}