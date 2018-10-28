using System.Collections.Generic;
using System.Linq;
using KMA.APZRPMJ2018.WalletSimulator.Models;

namespace KMA.APZRPMJ2018.WalletSimulator.Managers
{
    public class DBManager
    {
        private static readonly List<User> Users = new List<User>();

        static DBManager()
        {
            Users.Add(new User("Nata", "Rybak", "email@gmail.com", "n", "r"));
        }

        public static bool UserExists(string login)
        {
            return Users.Any(u => u.Login == login);
        }

        public static User GetUserByLogin(string login)
        {
            return Users.FirstOrDefault(u => u.Login == login);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
        
        
    }
}

