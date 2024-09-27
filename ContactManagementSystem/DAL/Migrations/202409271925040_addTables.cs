namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Address = c.String(nullable: false),
                        Categories = c.String(nullable: false),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CId)
                .ForeignKey("dbo.Users", t => t.UId, cascadeDelete: true)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Contacts", t => t.NoteId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 10, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.UId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "UId", "dbo.Users");
            DropForeignKey("dbo.Notes", "NoteId", "dbo.Contacts");
            DropIndex("dbo.Notes", new[] { "NoteId" });
            DropIndex("dbo.Contacts", new[] { "UId" });
            DropTable("dbo.Users");
            DropTable("dbo.Notes");
            DropTable("dbo.Contacts");
        }
    }
}
