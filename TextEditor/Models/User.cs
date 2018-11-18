using System;
using System.Collections.Generic;
using System.Linq;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
    [Serializable]
    public class User
    {
        #region Const

        private const string PrivateKey =
            "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent><P>6OkjEhjlvbDCuOl8e0Ep2zACTxkfSta8WFBmdvrinhQSowkT5xDXL0EFa/Z03XNUmjJ0xGe1aNCgG+6dDpTnSw==</P><Q>xHZTH4hXAv7uJsb/VHrcYOM5l4AyC+OxP7bhmAoGJGf4TpPxh+B0RhMxssrkc1d/72TIfRpuPbSLEqkqCSk5wQ==</Q><DP>SKFzK1CSTB4UCv/crr76Y3zMK4hlBryCDXQ9D7ta8frGeQr6puLMh9LZ8vnvJaOybUdwvFKu8pmkZDF7zrFGkw==</DP><DQ>J3ZNBAxyzds/IvLd3q4/DgcWTmQlqVW3CMFHVy7MRQvNSJtW7KAdOuYoGW2/rZtpy0BHNTnV4vcc6EaqduSdAQ==</DQ><InverseQ>4/jjapjJHdDqr5FG5a29ISgO6mRnjty6nrOisPNDi4336JdEKfAdtZvDUQoBAwKsV0oMvJ9RtPB2tS0hf5i8pA==</InverseQ><D>qcnyY/b5kbNxjasYvIQ5i3jTY2BLJ/YA9FcvXtiNw/DdGPMUiwGhrJnxEdD4yvyuBGm1CAmbV3d7icfjUBdYIe9VaZqPQ2FgYzI5DbB401+4z6Di7uKBVajLIOawlnufW4+K68T0EAFO2l9eo1RcU66W921G/pz6hObeUXt65QE=</D></RSAKeyValue>";

        private const string PubblicKey =
            "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        #endregion

        #region Fields

        private readonly List<Query> _queries;

        #endregion

        #region Properties

        public Guid Guid { get; private set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }

        public string Login { get; private set; }
        private string Password { get; set; }
        private DateTime LastLoginDate { get; set; }

        #endregion

        #region Constructor

        public User(string firstName, string lastName, string email, string login, string password)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            LastLoginDate = DateTime.Now;
            _queries = new List<Query>();

            SetPassword(password);
        }

        public void AddQuery(string filepath, QueryType type)
        {
            AddQuery(new Query(filepath, type));
        }

        public void AddQuery(Query q)
        {
            _queries.Add(q);
        }

        public List<Query> GetQueries(string filepath = null)
        {
            return filepath == null
                ? _queries.ToList()
                : _queries.Where(q => q.Filepath == filepath).ToList();
        }

        #endregion

        private void SetPassword(string password)
        {
            Password = Encrypting.GetMd5HashForString(password);
        }

        public bool CheckPassword(string password)
        {
            try
            {
                var res2 = Encrypting.GetMd5HashForString(password);
                return Password == res2;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckPassword(User userCandidate)
        {
            try
            {
                return Password == userCandidate.Password;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}