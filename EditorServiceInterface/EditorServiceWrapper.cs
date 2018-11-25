using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APZRPMJ2018.TextEditor.Models;

namespace KMA.APZRPMJ2018.TextEditor.ServiceInterface 
{
    public class EditorServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                client.AddQuery(query);
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                client.SaveQuery(query);
            }
        }

        public static List<User> GetAllUsers(Guid queryGuid)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                return client.GetAllUsers(queryGuid);
            }
        }

        public static void DeleteQuery(Query selectedQuery)
        {
            using (var myChannelFactory = new ChannelFactory<IEditorContract>("Server"))
            {
                IEditorContract client = myChannelFactory.CreateChannel();
                client.DeleteQuery(selectedQuery);
            }
        }

    }
}
