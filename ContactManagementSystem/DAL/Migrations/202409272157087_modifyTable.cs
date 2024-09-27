namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "NoteId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "NoteId");
        }
    }
}
