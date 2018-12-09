using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Serialization;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
    [Serializable]
    [DataContract(IsReference = true)]

    public class User
    {
        #region Const

        private const string PrivateKey =
            "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent><P>6OkjEhjlvbDCuOl8e0Ep2zACTxkfSta8WFBmdvrinhQSowkT5xDXL0EFa/Z03XNUmjJ0xGe1aNCgG+6dDpTnSw==</P><Q>xHZTH4hXAv7uJsb/VHrcYOM5l4AyC+OxP7bhmAoGJGf4TpPxh+B0RhMxssrkc1d/72TIfRpuPbSLEqkqCSk5wQ==</Q><DP>SKFzK1CSTB4UCv/crr76Y3zMK4hlBryCDXQ9D7ta8frGeQr6puLMh9LZ8vnvJaOybUdwvFKu8pmkZDF7zrFGkw==</DP><DQ>J3ZNBAxyzds/IvLd3q4/DgcWTmQlqVW3CMFHVy7MRQvNSJtW7KAdOuYoGW2/rZtpy0BHNTnV4vcc6EaqduSdAQ==</DQ><InverseQ>4/jjapjJHdDqr5FG5a29ISgO6mRnjty6nrOisPNDi4336JdEKfAdtZvDUQoBAwKsV0oMvJ9RtPB2tS0hf5i8pA==</InverseQ><D>qcnyY/b5kbNxjasYvIQ5i3jTY2BLJ/YA9FcvXtiNw/DdGPMUiwGhrJnxEdD4yvyuBGm1CAmbV3d7icfjUBdYIe9VaZqPQ2FgYzI5DbB401+4z6Di7uKBVajLIOawlnufW4+K68T0EAFO2l9eo1RcU66W921G/pz6hObeUXt65QE=</D></RSAKeyValue>";

        private const string PubblicKey =
            "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        #endregion

        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _email;
        [DataMember]
        private string _login;
        [DataMember]
        private string _password;
        [DataMember]
        private DateTime _lastLoginDate;
        [DataMember]
        [NonSerialized]
        private List<Query> _queries;
        #endregion

        #region Properties
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }
        private string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        private string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        private string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Login
        {
            get => _login;
            private set => _login = value;
        }
        private string Password
        {
            get => _password;
            set => _password = value;
        }
        private DateTime LastLoginDate
        {
            get => _lastLoginDate;
            set => _lastLoginDate = value;
        }

        public List<Query> Queries
        {
            get => _queries;
            private set => _queries = value;
        }
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

        private User()
        {
            _queries = new List<Query>();
        }


        public void AddQuery(string filepath, QueryType type)
        {
            AddQuery(new Query(filepath, type,this));
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
        #region EntityConfiguration

        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("Users");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsOptional();
                Property(p => p.Login)
                    .HasColumnName("Login")
                    .IsRequired();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(p => p.LastLoginDate)
                    .HasColumnName("LastLoginDate")
                    .IsRequired();

                HasMany(s => s.Queries)
                    .WithRequired(w => w.User)
                    .HasForeignKey(w => w.UserGuid)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}