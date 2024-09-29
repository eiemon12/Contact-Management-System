namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTokenTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "UserName", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserName" });
            AlterColumn("dbo.Tokens", "Key", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tokens", "UserName", c => c.String(nullable: false, maxLength: 10, unicode: false));
            CreateIndex("dbo.Tokens", "UserName");
            AddForeignKey("dbo.Tokens", "UserName", "dbo.Users", "UserName", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserName", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserName" });
            AlterColumn("dbo.Tokens", "UserName", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.Tokens", "Key", c => c.String());
            CreateIndex("dbo.Tokens", "UserName");
            AddForeignKey("dbo.Tokens", "UserName", "dbo.Users", "UserName");
        }
    }
}
