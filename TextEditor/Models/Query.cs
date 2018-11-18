using System;
using System.Data.Entity.ModelConfiguration;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
  public enum QueryType
    {
        Opened, Edited, NotEdited
    }
    
    public class Query
    {
        #region Fields
        private Guid _guid;
        private Guid _userGuid;
        private User _user;
        private DateTime _queryDateTime;
        private string _filepath;
        private QueryType _type;
        #endregion
//        public readonly DateTime QueryDateTime;
//        public readonly string Filepath;
//        public readonly QueryType Type;


        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }
        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }

        public  DateTime QueryDateTime
        {
            get { return _queryDateTime; }
            private set { _queryDateTime = value; }

        }

        public string Filepath
        {
            get { return _filepath; }
            private set { _filepath = value; }
        }

        public QueryType Type
        {
            get { return _type; }
            private set { _type = value; }
        }
        
        #endregion

        public Query(string filepath, QueryType type, User user)
        {
            _guid = Guid.NewGuid();
            QueryDateTime = DateTime.Now;
            Filepath = filepath;
            Type = type;
            _userGuid = user.Guid;
            _user = user;
        }

        public override string ToString()
        {
            return $"~ {Filepath} - {QueryDateTime:g} - {Type}";
        }

        #region EntityFrameworkConfiguration
        public class QueryEntityConfiguration : EntityTypeConfiguration<Query>
        {
            public QueryEntityConfiguration()
            {
                ToTable("Query");
                HasKey(s => s.Guid);
                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.Filepath)
                    .HasColumnName("Filepath")
                    .IsRequired();
                Property(s => s.QueryDateTime)
                    .HasColumnName("QueryDateTime")
                    .IsRequired();
                Property(s => s.Type)
                    .HasColumnName("Type")
                    .IsRequired();
            }
        }
        #endregion
        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}