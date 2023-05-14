using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    internal class MessageService
    {
        IMessageRepository _messageRepository;

        public MessageService()
        {
            _messageRepository = new MessageRepository();
        }

        public void Send(UserService userService,string email, string text)
        {
            if (userService == null || userService.FindByEmail()) { }
        }
    }
}
