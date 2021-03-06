﻿using System;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
    public enum QueryType
    {
        Opened, Edited, NotEdited
    }

   [DataContract(IsReference = true)]
    public class Query
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;
        [DataMember]
        private DateTime _queryDateTime;
       [DataMember]
        private string _filepath;
       [DataMember]
        private QueryType _type;
        #endregion

        #region Properties
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }
        public Guid UserGuid
        {
            get => _userGuid;
            private set => _userGuid = value;
        }
        public User User
        {
            get => _user;
            private set => _user = value;
        }

        public  DateTime QueryDateTime
        {
            get => _queryDateTime;
            private set => _queryDateTime = value;
        }
        public string Filepath
        {
            get => _filepath;
            private set => _filepath = value;
        }

        public QueryType Type
        {
            get => _type;
            private set => _type = value;
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

        private Query()
        {

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