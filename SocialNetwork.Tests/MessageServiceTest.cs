using NUnit.Framework;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;
using Moq;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.Tests
{
    [TestFixture]
    internal class MessageServiceTest
    {
        [Test]
        public void SendMessageMustReturnUserNotFoundEx()
        {
            var messageService = new MessageService();

            var message = new MessageData() { SenderId = 0, RecipientEmail = "mailqweqe122312e1@mail.ru", Content = "test" };
            Assert.Throws<UserNotFoundException>(() => messageService.SendMessage(message));

        }
    }
}
