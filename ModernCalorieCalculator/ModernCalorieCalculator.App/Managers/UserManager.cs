using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain.Entity;
using System;

namespace ModernCalorieCalculator.App.Managers
{
    public class UserManager
    {
        private readonly IUser _userService;

        public UserManager(IUser userService)
        {
            _userService = userService;
        }

        public int AddUser(User user)
        {
            if (user != null)
            {
                var userId = _userService.AddUser(user);
                return userId;
            }
            else
            {
                return 0;
            }
        }

        public User RegisterUser(string name, string lastName, string login)
        {
            var userByLogin = _userService.FindUserByLogin(login);
            if (userByLogin == null)
            {
                int id = _userService.GetLastId() + 1;
                var item = new User(id, name, lastName, login);
                _userService.AddUser(item);
                return item;
            }
            else
            {
                return null;
            }
        }

        public bool RegisterUserView()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Give me your name!");
            var name = Console.ReadLine();
            Console.WriteLine("Thank you! Now, give me your lastName!");
            var lastName = Console.ReadLine();
            Console.WriteLine("Thank you! Now, give me your nickName!");
            var login = Console.ReadLine();
            Console.WriteLine("Thank you! Now, give me your data of birth in format");
            var user = RegisterUser(name, lastName, login);

            if (user == null)
            {
                Console.WriteLine("There is a user with this login. Please enter a different login.");
                RegisterUserView();
            }
            else
            {
                Console.WriteLine("User added successfully.");
            }
            return true;
        }
        public User LogIn(string login)
        {
            var user = _userService.FindUserByLogin(login);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        public int LogInView()
        {
            Console.WriteLine("Logging into the 'Modern calculator calories' application");
            Console.Write("Login: ");
            var userLogin = Console.ReadLine();
            var user = LogIn(userLogin);
            if (user != null)
            {
                Console.WriteLine($"Hello, {user.Name}");
                return user.Id;
            }
            else
            {
                Console.WriteLine("User not found! \nPress any key...");
                Start();
                return 0;
            }
        }

        public int Start()
        {
            Console.WriteLine("If you don't have account, press key 1");
            Console.WriteLine("If you have account, press key 2");
            var operation = Console.ReadKey();
            if (operation.KeyChar == '1')
            {
                RegisterUserView();
                return LogInView();
            }
            else if (operation.KeyChar == '2')
            {
                return LogInView();
            }
            else
            {
                return 0;
            }
        }

    }
}
