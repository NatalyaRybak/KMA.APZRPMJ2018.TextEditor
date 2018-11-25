using KMA.APZRPMJ2018.TextEditor.Models;
using KMA.APZRPMJ2018.TextEditor.ServiceInterface;

namespace KMA.APZRPMJ2018.TextEditor.Managers
{
    public class DbManager
    {
        public static bool UserExists(string login)
        {
            return EditorServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EditorServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EditorServiceWrapper.AddUser(user);
        }

        public static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EditorServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void AddQuery(Query query)
        {
            EditorServiceWrapper.AddQuery(query);
        }

    }
}

