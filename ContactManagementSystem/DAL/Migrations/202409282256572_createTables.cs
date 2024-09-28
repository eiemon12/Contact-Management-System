namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Birthday = c.String(),
                        Category = c.String(),
                        Notes = c.String(),
                        UserName = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        UserName = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserName)
                .Index(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserName", "dbo.Users");
            DropForeignKey("dbo.Contacts", "UserName", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserName" });
            DropIndex("dbo.Contacts", new[] { "UserName" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
        }
    }
}
