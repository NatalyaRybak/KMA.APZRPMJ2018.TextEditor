using KMA.APZRPMJ2018.TextEditor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.APZRPMJ2018.TextEditor
{
    internal class EditorDBContext : DbContext
    {
        public EditorDBContext() : base("NewEditorDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EditorDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Query.QueryEntityConfiguration());
        }
    }
}
