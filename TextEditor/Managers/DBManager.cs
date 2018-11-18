using System.Collections.Generic;
using System.Linq;
using KMA.APZRPMJ2018.TextEditor.Models;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    internal class DbManager
    {
        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        internal static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void AddQuery(Query query)
        {
            EntityWrapper.AddQuery(query);
        }

    }
}

