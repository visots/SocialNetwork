using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository _messageRepository;
        IUserRepository _userRepository;
        public MessageService()
        {
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
        }
          
        public void SendMessage(MessageData messageData)
        {
            if (String.IsNullOrEmpty(messageData.Content))
                throw new ArgumentNullException();

            if (messageData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            var recipient = this._userRepository.FindByEmail(messageData.RecipientEmail);
            if (recipient == null)
                throw new UserNotFoundException();

            var message = new MessageEntity()
            {
                content = messageData.Content,
                sender_id = messageData.SenderId,
                recipient_id = recipient.id,
            };

            if (this._messageRepository.Create(message) == 0)
                throw new Exception();
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var sender = _userRepository.FindById(m.sender_id);
                var recipient = _userRepository.FindById(m.recipient_id);
                messages.Add(new Message(m.id, m.content, sender.email, recipient.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            _messageRepository.FindByRecipientId(senderId).ToList().ForEach(m =>
            {
                var sender = _userRepository.FindById(m.sender_id);
                var recipient = _userRepository.FindById(m.recipient_id);
                messages.Add(new Message(m.id, m.content, sender.email, recipient.email));
            });

            return messages;
        }

    }
}
