using System.Data.Entity.Migrations;

namespace KMA.APZRPMJ2018.TextEditor.DBAdapter
{
    internal sealed class Configuration : DbMigrationsConfiguration<EditorDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EditorDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
