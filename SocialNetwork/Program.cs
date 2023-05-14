using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Hello");
                Console.WriteLine("Для регистрации введите имя:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Фамилию:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Email:");
                string email = Console.ReadLine();

                Console.WriteLine("Пароль:");
                string password = Console.ReadLine();

                var userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация завершена");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректные значения");
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла ошибка при регистрации");
                }

                Console.ReadLine();
            }
        }
    }
}