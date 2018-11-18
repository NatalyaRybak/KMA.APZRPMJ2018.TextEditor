namespace KMA.APZRPMJ2018.TextEditor
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Query",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        QueryDateTime = c.DateTime(nullable: false),
                        Filepath = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.UserGuid, cascadeDelete: true)
                .Index(t => t.UserGuid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Query", "UserGuid", "dbo.Users");
            DropIndex("dbo.Query", new[] { "UserGuid" });
            DropTable("dbo.Users");
            DropTable("dbo.Query");
        }
    }
}
