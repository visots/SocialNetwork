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
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend> FindAllByUserId(int userId)
        {
            var friends = new List<Friend>();
            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var user = userRepository.FindById(userId);
                var friend = userRepository.FindById(f.friend_id);
                friends.Add(new Friend(f.id,user.email,friend.email));
            });

            if (friendRepository is null) throw new FriendNotFoundException();

            return friends;
        }

        public void CreateFriend(FriendData friendData)
        {
            if (friendData == null) throw new ArgumentNullException();

            var friendUser = this.userRepository.FindByEmail(friendData.FriendEmail);

            if (friendUser is null)
                throw new UserNotFoundException();

            var friend = new FriendEntity()
            {
                friend_id=friendUser.id,
                user_id = friendData.UserId
            };

            if (this.friendRepository.Create(friend) == 0)
                throw new Exception();
        }

        public void DeleteFriend(FriendData friendData)
        {
            if (friendData == null) throw new ArgumentNullException();

            if (this.friendRepository.Delete(friendData.Id) == 0)
                throw new Exception();
        }
    }
}
