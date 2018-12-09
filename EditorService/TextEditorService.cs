using System;
using System.Collections.Generic;
using KMA.APZRPMJ2018.TextEditor.DBAdapter;
using KMA.APZRPMJ2018.TextEditor.Models;
using KMA.APZRPMJ2018.TextEditor.ServiceInterface;

namespace KMA.APZRPMJ2018.TextEditor.EditorService
{

    class TextEditorService: IEditorContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddQuery(Query query)
        {
            EntityWrapper.AddQuery(query);
        }
        
        public List<User> GetAllUsers(Guid queryGuid)
        {
            return EntityWrapper.GetAllUsers(queryGuid);
        }
        
        public void DeleteQuery(Query selectedQuery)
        {
            EntityWrapper.DeleteQuery(selectedQuery);
        }


        public void SaveQuery(Query query)
        {
            EntityWrapper.SaveQuery(query);
        }
    }
}
