namespace ChatWithSignalRAndWinServMVC.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeChat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chats", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chats", "Name");
        }
    }
}
