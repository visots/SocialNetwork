using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendMenu
    {
        UserService userService;

        public UserFriendMenu(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            var friendService = new FriendService();

            Console.WriteLine("\tПросмотреть список друзей (нажмите 1)");
            Console.WriteLine("\tДобавить в друзья (нажмите 2)");

            string keyValue = Console.ReadLine();

            switch (keyValue)
            {
                case "1":
                    {
                        Console.WriteLine("Ваши друзья:");

                        try
                        {
                            var firends = friendService.FindAllByUserId(user.Id);
                            foreach (var firend in firends)
                                Console.WriteLine(firend.FriendEmail);

                            Console.WriteLine();
                        }
                        catch (FriendsNotFoundException)
                        {
                            AlertMessage.Show("Друзья не найдены");
                        }
                        break;
                    }
                case "2":
                    {

                        Console.WriteLine("Введите почтвый адрес друга:");
                        string friendEmail = Console.ReadLine();
                        try
                        {
                            user = userService.FindById(user.Id);

                            var friend = userService.FindByEmail(friendEmail);

                            var friendShip = new FriendData
                            {
                                UserId = user.Id,
                                FriendEmail = friendEmail
                            };

                            friendService.CreateFriend(friendShip);

                            SuccessMessage.Show("Пользователь добавлен в друзья");
                        }
                        catch (UserNotFoundException)
                        {
                            AlertMessage.Show("Пользователь не найден");
                        }
                        catch (Exception ex)
                        {
                            AlertMessage.Show(ex.ToString());
                        }
                        break;
                    }
            }
        }
    }
}
