using System;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
    public enum QueryType
    {
        Opened, Edited, NotEdited
    }
    [Serializable]
    public class Query
    {
        public readonly DateTime QueryDateTime;
        public readonly string Filepath;
        public readonly QueryType Type;

        public Query(string filepath, QueryType type)
        {
            QueryDateTime = DateTime.Now;
            Filepath = filepath;
            Type = type;
        }

        public override string ToString()
        {
            return $"~ {Filepath} - {QueryDateTime:g} - {Type}";
        }
    }
}