using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APZRPMJ2018.TextEditor.Models;

namespace KMA.APZRPMJ2018.TextEditor.ServiceInterface 
{
    [ServiceContract]
    public interface IEditorContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid walletGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddQuery(Query query);
        [OperationContract]
        void SaveQuery(Query query);
        [OperationContract]
        void DeleteQuery(Query selectedQuery);
    }
}
