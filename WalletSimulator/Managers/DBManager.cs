﻿using System.Collections.Generic;
using System.Linq;
using KMA.APZRPMJ2018.TextEditor.Models;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    public class DBManager
    {
        private static readonly List<User> Users = new List<User>();

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

